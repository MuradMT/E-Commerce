using System.Text.Json;

namespace E_Commerce_Backend.Application.Exceptions;

public class ExceptionModel:ErrorStatusCode
{
    public IEnumerable<string>? Errors { get; set; }

    public override  string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}