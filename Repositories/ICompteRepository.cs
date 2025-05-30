using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Models.Domain;

namespace ecommerce.Repositories
{
    public interface ICompteRepository
    {
        Task<User?> GetByEmailAndPasswordAsync(string email, string password);
        Task CreateAsync(User compte);
    }
}