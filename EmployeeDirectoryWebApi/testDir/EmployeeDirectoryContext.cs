using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectoryApp.testDir;

public partial class EmployeeDirectoryContext : DbContext
{
    public EmployeeDirectoryContext()
    {
    }

    public EmployeeDirectoryContext(DbContextOptions<EmployeeDirectoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-9RQ7QCJR;Database=EmployeeDirectory;Trusted_Connection=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.Office)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.PrefferedName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.SkypeId)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
