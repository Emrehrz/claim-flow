using System.IO;
using System.Threading.Tasks;

namespace ClaimFlow.Application.Interfaces.Storage;

public interface ILocalStorageService
{
    Task<string> SaveFileAsync(Stream fileStream, string fileName, string subFolder = "claims");
}