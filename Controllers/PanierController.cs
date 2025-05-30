using System.Security.Claims;
using ecommerce.Data;
using ecommerce.Models.Domain;
using ecommerce.Models.ViewModels;
using ecommerce.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    [Authorize(Roles = "Client")]
    public class PanierController : Controller
    {
        private readonly MyDbContext context;
        private readonly IProduitRepository produitRepository;
        public PanierController(MyDbContext context, IProduitRepository produitRepository)
        {
            this.produitRepository = produitRepository;
            this.context = context;

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddPanier(int id)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Auth");
            }

            var panierItem = await context.Produits.FirstOrDefaultAsync(p => p.Id == id);

            ViewBag.ProduitId = panierItem;

            if (panierItem == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var addPanier = new AddPanier
            {
                UtilisateurId = int.Parse(userId),
                ProduitId = id,
            };

            return View(addPanier);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPanier(AddPanier model)
        {
            var produitExiste = await context.Produits.FindAsync(model.ProduitId);
            if (produitExiste == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var panierItem = new PanierItem
            {
                UtilisateurId = model.UtilisateurId,
                ProduitId = model.ProduitId,
                Quantite = model.Quantite
            };

            context.PanierItems.Add(panierItem);
            await context.SaveChangesAsync();

            // Tu peux rediriger vers la liste ou la page panier
            return RedirectToAction("Index", "Produit");
        }

        [HttpGet]
        public async Task<IActionResult> GetListPanier()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Auth");
            }

            int userParseId = int.Parse(userId);

            var panierItems = await context.PanierItems
                .Where(p => p.UtilisateurId == userParseId)
                .Include(p => p.Produit)
                .ToListAsync();

            return View(panierItems);
        }


    }
}