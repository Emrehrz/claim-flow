using FluentValidation;
using ClaimFlow.Application.DTOs.Policy;
using System.Text.Json;


namespace ClaimFlow.Application.Validators.Policy;

public class CreatePolicyDtoValidator : AbstractValidator<CreatePolicyDto>
    {
        public CreatePolicyDtoValidator()
        {
            RuleFor(x => x.PolicyNumber).NotEmpty();
            RuleFor(x => x.VehicleId).NotEmpty();
            
            // Başlangıç tarihi, bitiş tarihinden önce olmalı
            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate)
                .WithMessage("Start date must be before end date.");

            // CoverageSummary geçerli bir JSON formatında olmalı
            RuleFor(x => x.CoverageSummary)
                .NotEmpty()
                .Must(BeAValidJson)
                .WithMessage("CoverageSummary must be a valid JSON string.");
        }

        private bool BeAValidJson(string jsonString)
        {
            try
            {
                JsonDocument.Parse(jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

