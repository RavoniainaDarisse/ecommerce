using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Models.Domain;

namespace ecommerce.Repositories
{
    public interface IProduitRepository
    {
        Task<IEnumerable<Produit>> GetAllAsync();
        Task<Produit?> GetByIdAsync(int id);
        Task CreateAsync(Produit produit);
        Task UpdateAsync(Produit produit);
        Task DeleteAsync(int id);
    }
}