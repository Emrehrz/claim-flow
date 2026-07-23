using ClaimFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClaimFlow.Infrastructure.Data.Configurations;

public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
{
  public void Configure(EntityTypeBuilder<Policy> builder)
  {
    builder.HasKey(p=> p.Id);

    builder.Property(p=> p.PolicyNumber)
    .IsRequired()
    .HasMaxLength(50);

    // PostgreSQL icin JSONB tipi eslesmesi
    builder.Property(p=> p.CoverageSummary)
    .HasColumnType("jsonb");

    //  Vehicle ile iliski (1 to many)
    builder.HasOne(p=> p.Vehicle)
    .WithMany(v=> v.Policies)
    .HasForeignKey(p=> p.VehicleId)
    .OnDelete(DeleteBehavior.Cascade);
  }
}