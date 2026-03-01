namespace Domain;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    

    // Parameterless constructor for EF Core
    private Customer() { }

    public Customer(int id,string firstname, string lastname)
    {
        Id = id;
        FirstName = firstname;
        LastName = lastname;
    }
}