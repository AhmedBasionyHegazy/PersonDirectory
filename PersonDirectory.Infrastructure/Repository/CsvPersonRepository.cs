

using Microsoft.Extensions.Configuration;
using PersonDirectory.Core.DTO;
using PersonDirectory.Core.Models;
using PersonDirectory.Core.RepositoryContract;

namespace PersonDirectory.Infrastructure.Repository;
public class CsvPersonRepository : IPersonRepository
{
    private readonly string _filePath;

    public CsvPersonRepository(IConfiguration config)
    {
        _filePath = config["DataSources:CsvPath"];
    }

    public async Task<IEnumerable<ResponseDto>> GetPersonsAsync(string? searchTerm)
    {
        var lines = await File.ReadAllLinesAsync(_filePath);
        var persons = new List<ResponseDto>();

        foreach (var line in lines.Skip(1)) // Skip header optional based on your file structure
        {
            var parts = line.Split(',');
            var person = new ResponseDto
            {
                FirstName = parts[0],
                LastName = parts[1],
                TelephoneCode = parts[3],
                TelephoneNumber = parts[4],
                Address = parts[5],
                Country = parts[6]
            };

            if (string.IsNullOrEmpty(searchTerm) ||
                person.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                person.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                person.Country.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) 
            {
                persons.Add(person);
            }
        }

        return persons;
    }
}
