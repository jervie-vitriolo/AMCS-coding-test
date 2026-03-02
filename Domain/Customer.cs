namespace Domain;

public class Customer
{
    public string Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    

    // Parameterless constructor for EF Core
    private Customer() { }

    public Customer(string id,string firstname, string lastname)
    {
        Id = id;
        FirstName = firstname;
        LastName = lastname;
    }
}