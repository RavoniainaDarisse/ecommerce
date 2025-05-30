
using ecommerce.Data;
using ecommerce.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly MyDbContext _context;

        public CategorieRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categorie>> GetAllAsync()
            => await _context.Categories.ToListAsync();

        public async Task<Categorie?> GetByIdAsync(int id)
            => await _context.Categories.FindAsync(id);

        public async Task CreateAsync(Categorie categorie)
        {
            await _context.Categories.AddAsync(categorie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Categorie categorie)
        {
            _context.Categories.Update(categorie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var categorie = await GetByIdAsync(id);
            if (categorie != null)
            {
                _context.Categories.Remove(categorie);
                await _context.SaveChangesAsync();
            }
        }

      
    }
}