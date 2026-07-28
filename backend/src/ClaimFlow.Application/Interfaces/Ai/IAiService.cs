using System.Threading.Tasks;

namespace ClaimFlow.Application.Interfaces.Ai;

public interface IAiService
{
    Task<string> AnalyzeClaimAsync(string description, int photoCount);
}