using PersonDirectory.Core.DTO;
using PersonDirectory.Core.Models;
using PersonDirectory.Core.RepositoryContract;

namespace PersonDirectory.Core.Service;
public class PersonService
{
    private readonly IEnumerable<IPersonRepository> _repositories;

    public PersonService(IEnumerable<IPersonRepository> repositories)
    {
        _repositories = repositories;
    }

    public async Task<IEnumerable<ResponseDto>> GetPersonsAsync(string? searchTerm)
    {
        var tasks = _repositories.Select(repo => repo.GetPersonsAsync(searchTerm));
        var results = await Task.WhenAll(tasks);
        return results.SelectMany(x => x);
    }
}
