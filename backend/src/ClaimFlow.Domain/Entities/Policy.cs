using System;
using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Domain.Entities;

public class Policy
{
    public Guid Id {get;set;}
    public Guid VehicleId { get; set; }
        
        public string PolicyNumber { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public PolicyStatus Status { get; set; }
        
        // JSON formatında tutulacak alan
        public string CoverageSummary { get; set; } = string.Empty;

        // Navigation Property
        public virtual Vehicle? Vehicle { get; set; }

        public ICollection<Claim> Claims { get; set; } = new List<Claim>();
}