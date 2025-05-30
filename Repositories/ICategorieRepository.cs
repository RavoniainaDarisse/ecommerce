
using ecommerce.Models.Domain;

namespace ecommerce.Repositories
{
    public interface ICategorieRepository
    {
        Task<List<Categorie>> GetAllAsync();
        Task<Categorie?> GetByIdAsync(int id);
        Task CreateAsync(Categorie categorie);
        Task UpdateAsync(Categorie categorie);
        Task DeleteAsync(int id);
    }
}