namespace Domain;

public class Job
{
    public Guid Id { get; set; }

    public DateTime StartDate { get; set; } = default!;

    public DateTime DueDate { get; set; } = default!;
    
    public double Budget { get; set; } = default!;

    public string Description { get; set; } = default!;

    public int AcceptedBy { get; set; } = default!;




    // Parameterless constructor for EF Core
    private Job() { }

    public Job(Guid id, DateTime startdate, DateTime duedate, double budget,string description, int acceptedby)
    {
        Id = Guid.NewGuid();
        StartDate = startdate;
        DueDate = duedate;
        Budget = budget;
        Description = description;
        AcceptedBy = acceptedby;

    }
}