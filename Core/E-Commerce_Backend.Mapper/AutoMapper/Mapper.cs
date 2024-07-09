
using AutoMapper;
using AutoMapper.Internal;


namespace E_Commerce_Backend.Mapper.AutoMapper;

public class Mapper : Application.Interfaces.AutoMapper.IMapper
{
    public static List<TypePair> typePairs = new();
    IMapper? MapperContainer;

    public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
    {
        Config<TDestination, TSource>(5, ignore);
        return MapperContainer!.Map<TSource, TDestination>(source);

    }

    public TDestination Map<TDestination>(object source, string? ignore = null)
    {
        Config<TDestination, object>(5, ignore);
        return MapperContainer!.Map<TDestination>(source);
    }

    public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
    {
        Config<IList<TDestination>, IList<TSource>>(5, ignore);
        return MapperContainer!.Map<IList<TSource>, IList<TDestination>>(source);
    }

    public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
    {
        Config<IList<TDestination>, IList<object>>(5, ignore);
        return MapperContainer!.Map<IList<TDestination>>(source);
    }
    /// <summary>
    /// This method helps us does not create mappings for each entity,simply acting as profile.
    /// </summary>
    protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
    {
        var typePair = new TypePair(typeof(TSource), typeof(TDestination));

        if (
        typePairs.Any(a => a.DestinationType == typePair.DestinationType &&
        a.SourceType == typePair.SourceType)
        && ignore is null
        )
            return;

        typePairs.Add(typePair);

        var config = new MapperConfiguration(cfg =>
        {
            foreach (var pair in typePairs)
            {
                if (ignore is not null)
                {
                    cfg.CreateMap(pair.SourceType, pair.DestinationType)
                    .MaxDepth(depth).ForMember(ignore, x => x.Ignore()).ReverseMap();
                }
                else
                {
                    cfg.CreateMap(pair.SourceType, pair.DestinationType)
                    .MaxDepth(depth).ReverseMap();
                }
            }
        });

        MapperContainer = config.CreateMapper();
    }
}
