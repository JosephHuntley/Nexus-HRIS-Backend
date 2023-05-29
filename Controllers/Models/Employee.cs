using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Controller.Models;

namespace Nexus.Models;

public class Employee : Model

{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

    [InverseProperty("employee")]
    public virtual ICollection<PayStub>? PayStubs { get; set; }

    public virtual VacationTime? Vacation { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public bool Terminated { get; set; }

    public DateTime TerminatedDate { get; set; }
}