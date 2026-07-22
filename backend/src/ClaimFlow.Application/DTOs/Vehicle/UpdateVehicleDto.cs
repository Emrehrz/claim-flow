namespace ClaimFlow.Application.DTOs.Vehicle;

public class UpdateVehicleDto
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
}
