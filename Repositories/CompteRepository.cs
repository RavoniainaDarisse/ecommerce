using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Data;
using ecommerce.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Repositories
{
    public class CompteRepository : ICompteRepository
    {
        private readonly MyDbContext _context;

    public CompteRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAndPasswordAsync(string email, string password)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.MotDePasse == password); 
    }

    public async Task CreateAsync(User compte)
    {
        _context.Users.Add(compte);
        await _context.SaveChangesAsync();
    }
    }
}