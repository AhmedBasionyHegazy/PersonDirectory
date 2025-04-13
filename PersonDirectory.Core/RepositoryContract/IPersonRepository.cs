
using PersonDirectory.Core.DTO;
using PersonDirectory.Core.Models;

namespace PersonDirectory.Core.RepositoryContract;
public interface IPersonRepository
{
    Task<IEnumerable<ResponseDto>> GetPersonsAsync(string? searchTerm);
}
