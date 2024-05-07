namespace AvBeacon.Domain.Entities;

public class JobApplication
{
    public required Candidate Candidate { get; set; }
    public required JobOffer JobOffer { get; set; }
}