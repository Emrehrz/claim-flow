namespace ClaimFlow.Application.DTOs.Vehicle;

public class VehicleDto
{
    public Guid Id { get; set; }
    public string PlateNumber { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public Guid UserId { get; set; }
}
