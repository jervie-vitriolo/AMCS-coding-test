namespace Domain;

public class Contractor
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Rating { get; set; } = default!;
    

    // Parameterless constructor for EF Core
    private Contractor() { }

    public Contractor(int id,string name, int rating)
    {
        Id = id;
        Name = name;
        Rating = rating;
    }
}