using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using ecommerce.Models;
using ecommerce.Models.Domain;
using System.Security.Claims;  

namespace ecommerce.Controllers
{
//    [Authorize]
   // Injecter les services nécessaires via le constructeur :
// - DbContext
// - IHttpContextAccessor pour obtenir l'utilisateur connecté

public class CommandeController : Controller
{
    private readonly MyDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CommandeController(MyDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost]
    public async Task<IActionResult> ValiderCommande()
    {
        // 🔐 Obtenir l'utilisateur connecté
        var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst("id")?.Value);

        // 🛒 Récupérer les items du panier de l'utilisateur
        var panierItems = await _context.PanierItems
            .Include(p => p.Produit)
            .Where(p => p.UtilisateurId == userId)
            .ToListAsync();

        if (!panierItems.Any())
        {
            return BadRequest("Le panier est vide.");
        }

        // 💵 Calcul du total
        decimal total = panierItems.Sum(item => item.Produit.Prix * item.Quantite);

        // ✅ Créer la commande
        var commande = new Commande
        {
            UtilisateurId = userId,
            DateCommande = DateTime.Now,
            Statut = "En cours",
            Total = total,
            CommandeItems = new List<CommandeItem>()
        };

        foreach (var item in panierItems)
        {
            commande.CommandeItems.Add(new CommandeItem
            {
                ProduitId = item.ProduitId,
                Quantite = item.Quantite,
                PrixUnitaire = item.Produit.Prix
            });
        }

        // 💾 Sauvegarder la commande
        _context.Commandes.Add(commande);

        // 🧹 Supprimer les items du panier
        _context.PanierItems.RemoveRange(panierItems);

        await _context.SaveChangesAsync();

        // 🚀 Rediriger ou retourner une réponse
        return RedirectToAction("Confirmation");
    }

    public  async Task<IActionResult>  Confirmation()
    {
           var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
    if (userIdClaim == null)
        return Unauthorized();

    int userId = int.Parse(userIdClaim.Value);

    var commandes = await _context.Commandes
        .Include(c => c.CommandeItems)
            .ThenInclude(ci => ci.Produit)
        .Where(c => c.UtilisateurId == userId)
        .OrderByDescending(c => c.DateCommande)
        .ToListAsync();

    return View(commandes);
    }

    [Authorize(Roles = "Admin")]
[HttpGet]
public async Task<IActionResult> ToutesLesCommandes()
{
    var commandes = await _context.Commandes
        .Include(c => c.CommandeItems)
            .ThenInclude(ci => ci.Produit)
        .Include(c => c.Utilisateur) // si tu as une navigation Utilisateur
        .OrderByDescending(c => c.DateCommande)
        .ToListAsync();

    return View(commandes);
}

}

}