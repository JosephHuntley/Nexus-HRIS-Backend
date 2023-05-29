namespace Nexus.Models.DTO;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public decimal PayRate { get; set; }
    public string Title { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
}