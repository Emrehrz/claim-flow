using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Application.DTOs.Policy;

  public class PolicyDto
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PolicyStatus Status { get; set; }
        public string CoverageSummary { get; set; } = string.Empty;
    }

    public class CreatePolicyDto
    {
        public Guid VehicleId { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CoverageSummary { get; set; } = string.Empty;
    }

    public class UpdatePolicyDto
    {
        public DateTime EndDate { get; set; }
        public string CoverageSummary { get; set; } = string.Empty;
        public PolicyStatus Status { get; set; }
    }