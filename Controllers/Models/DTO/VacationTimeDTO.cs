using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controller.Models.DTO;

public class VacationTimeDTO
{
    public int Id { get; set; }

    [Column(TypeName = "real")]
    public double VacationAvailable { get; set; }

    [Column(TypeName = "real")]
    public double VacationAvail { get; set; }

    [Column(TypeName = "real")]
    public double HolidayAvailable { get; set; }

    [Column(TypeName = "real")]
    public double HolidayAvail { get; set; }

    [Column(TypeName = "INT")]
    public int EmployeeId { get; set; }


}


