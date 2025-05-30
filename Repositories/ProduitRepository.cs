
using ecommerce.Data;
using ecommerce.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Repositories
{
    public class ProduitRepository : IProduitRepository
    {
          private readonly MyDbContext _context;

        public ProduitRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produit>> GetAllAsync()
        {
            return await _context.Produits
                .Include(p => p.Categorie)
                .ToListAsync();
        }

        public async Task<Produit?> GetByIdAsync(int id)
        {
            return await _context.Produits
                .Include(p => p.Categorie)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateAsync(Produit produit)
        {
            await _context.Produits.AddAsync(produit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produit produit)
        {
            _context.Produits.Update(produit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produit = await _context.Produits.FindAsync(id);
            if (produit != null)
            {
                _context.Produits.Remove(produit);
                await _context.SaveChangesAsync();
            }
        }
    }
}