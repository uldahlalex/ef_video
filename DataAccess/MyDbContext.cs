using System;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public partial class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientTreatment> PatientTreatments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("diagnoses_pkey");

            entity.Property(e => e.DiagnosisDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Disease).WithMany(p => p.Diagnoses).HasConstraintName("diagnoses_disease_id_fkey");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Diagnoses).HasConstraintName("diagnoses_doctor_id_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Diagnoses).HasConstraintName("diagnoses_patient_id_fkey");
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("diseases_pkey");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doctors_pkey");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("patients_pkey");
        });

        modelBuilder.Entity<PatientTreatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("patient_treatments_pkey");

            entity.Property(e => e.StartDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientTreatments).HasConstraintName("patient_treatments_patient_id_fkey");

            entity.HasOne(d => d.Treatment).WithMany(p => p.PatientTreatments).HasConstraintName("patient_treatments_treatment_id_fkey");
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("treatments_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
