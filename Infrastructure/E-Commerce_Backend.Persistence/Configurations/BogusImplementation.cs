namespace E_Commerce_Backend.Persistence.Configurations;

public class BogusImplementation
{ 
    /// <summary>
    /// Bogus has COMMERCE property which includes e-commerce related things inside 
    /// like product name,description,department etc.
    /// </summary>
     /// <summary>
    /// Bogus has FINANCE property which includes finance related things inside
    /// such as amount.
    /// </summary>
    /// <summary>
    /// Bogus has LOREM which generates words,setences etc.
    /// </summary>
    /// <summary>
    /// Bogus has RANDOM which generates random things such as decimal,digit,guid etc.
    /// </summary>
    public Faker faker = new();
    //you can change locale,like new Faker("az")
}
