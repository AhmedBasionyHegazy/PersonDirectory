
using Microsoft.EntityFrameworkCore;
using PersonDirectory.Core.DTO;
using PersonDirectory.Core.Models;
using PersonDirectory.Core.RepositoryContract;
using PersonDirectory.Infrastructure.DBContext;
using System;

namespace PersonDirectory.Infrastructure.Repository;
public class SqlPersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;

    public SqlPersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ResponseDto>> GetPersonsAsync(string? searchTerm)
    {
        var query = _context.Person_Details.AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(p =>
                p.Name.Contains(searchTerm) ||
                p.Country.Contains(searchTerm));
        }

        var Person_Details= await query.ToListAsync();

        if(Person_Details.Count > 0)
        {
            return Person_Details.Select(x=> new ResponseDto 
            { 
                FirstName=x.Name.Split(" ")[0],
                LastName= x.Name.Split(" ")[1],
                Address=x.Address,
                Country=x.Country,
                TelephoneCode=x.TelephoneNumber.Split("-")[0],
                TelephoneNumber=x.TelephoneNumber.Split("-")[1],
             }).ToList();
        }
        return Enumerable.Empty<ResponseDto>();
    }
}
