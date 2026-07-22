using ClaimFlow.Application.DTOs.Vehicle;
using FluentValidation;

namespace ClaimFlow.Application.Validators.Vehicle;

public class CreateVehicleDtoValidator : AbstractValidator<CreateVehicleDto>
{
    public CreateVehicleDtoValidator()
    {
        RuleFor(x => x.PlateNumber)
            .NotEmpty().WithMessage("Plate number is required.")
            .MaximumLength(20).WithMessage("Plate number must not exceed 20 characters.");

        RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("Brand is required.")
            .MaximumLength(100).WithMessage("Brand must not exceed 100 characters.");

        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model is required.")
            .MaximumLength(100).WithMessage("Model must not exceed 100 characters.");

        RuleFor(x => x.Year)
            .GreaterThan(1900).WithMessage("Year must be valid.")
            .LessThanOrEqualTo(DateTime.UtcNow.Year + 1).WithMessage("Year cannot be in the future.");
    }
}
