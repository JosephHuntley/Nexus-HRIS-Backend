using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nexus.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controller.Models.DTO;

public class PayStubDTO
{
    public int Id { get; set; }
    // Before Taxes
    [Column(TypeName = "money")]
    public decimal Gross { get; set; }
    public decimal Net { get; set; }
    public decimal FederalTaxes { get; set; }
    public decimal FICATaxes { get; set; }
    public decimal MedicareTaxes { get; set; }
    public decimal StateTaxes { get; set; }
    public decimal Deductions401K { get; set; }
    public double HoursWorked { get; set; }
    public DateTime Date { get; set; }
    public short Week { get; set; }
    public int EmployeeId { get; set; }

}


