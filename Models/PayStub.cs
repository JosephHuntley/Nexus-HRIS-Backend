using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Controller.Models;
using Nexus.Models;

namespace Nexus.Models
{
    public class PayStub : Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Before Taxes
        public decimal Gross { get; set; }

        // After Taxes
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

        [ForeignKey("EmployeeId")]
        public virtual Employee? employee { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }


    }
}

