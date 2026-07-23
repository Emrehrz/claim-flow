using Mapster;
using System;
using ClaimFlow.Domain.Entities;
using ClaimFlow.Application.DTOs.Policy;
using ClaimFlow.Domain.Enums;

namespace ClaimFlow.Application.Mappings{
  
 public class PolicyMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Policy, PolicyDto>()
                .Map(dest => dest.Status, src => 
                    (src.EndDate < DateTime.UtcNow && src.Status == PolicyStatus.Active) 
                        ? PolicyStatus.Expired 
                        : src.Status);
        }
    }
}



