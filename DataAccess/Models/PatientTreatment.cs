using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("patient_treatments")]
public partial class PatientTreatment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("patient_id")]
    public int PatientId { get; set; }

    [Column("treatment_id")]
    public int TreatmentId { get; set; }

    [Column("start_date")]
    public DateTime? StartDate { get; set; }

    [Column("end_date")]
    public DateTime? EndDate { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("PatientTreatments")]
    public virtual Patient Patient { get; set; } = null!;

    [ForeignKey("TreatmentId")]
    [InverseProperty("PatientTreatments")]
    public virtual Treatment Treatment { get; set; } = null!;
}
