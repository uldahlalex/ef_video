using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("diagnoses")]
public partial class Diagnosis
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("patient_id")]
    public int PatientId { get; set; }

    [Column("disease_id")]
    public int DiseaseId { get; set; }

    [Column("diagnosis_date")]
    public DateTime? DiagnosisDate { get; set; }

    [Column("doctor_id")]
    public int DoctorId { get; set; }

    [ForeignKey("DiseaseId")]
    [InverseProperty("Diagnoses")]
    public virtual Disease Disease { get; set; } = null!;

    [ForeignKey("DoctorId")]
    [InverseProperty("Diagnoses")]
    public virtual Doctor Doctor { get; set; } = null!;

    [ForeignKey("PatientId")]
    [InverseProperty("Diagnoses")]
    public virtual Patient Patient { get; set; } = null!;
}
