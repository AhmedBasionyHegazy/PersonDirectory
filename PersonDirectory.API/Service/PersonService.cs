using PersonDirectory.Core.Models;
using PersonDirectory.Core.RepositoryContract;

namespace PersonDirectory.API.Service;
public class PersonService
{
    private readonly IEnumerable<IPersonRepository> _repositories;

    public PersonService(IEnumerable<IPersonRepository> repositories)
    {
        _repositories = repositories;
    }

    public async Task<IEnumerable<Person_Detail>> GetPersonsAsync(string? searchTerm)
    {
        var tasks = _repositories.Select(repo => repo.GetPersonsAsync(searchTerm));
        var results = await Task.WhenAll(tasks);
        return results.SelectMany(x => x);
    }
}
