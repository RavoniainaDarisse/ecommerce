using ecommerce.Models.Domain;
using ecommerce.Models.ViewModels;
using ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace ecommerce.Controllers
{
    [Authorize]
    public class ProduitController : Controller
    {
        private readonly IProduitRepository _produitRepository;
        private readonly ICategorieRepository _categorieRepository;

        public ProduitController(IProduitRepository produitRepository, ICategorieRepository categorieRepository)
        {
            _produitRepository = produitRepository;
            _categorieRepository = categorieRepository;
        }

        public async Task<IActionResult> Index()
        {
            var produits = await _produitRepository.GetAllAsync();
            return View(produits);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categorieRepository.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProduitViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categorieRepository.GetAllAsync();
                return View(model);
            }

            var produit = new Produit
            {
                Nom = model.Nom,
                Description = model.Description,
                Prix = model.Prix,
                Stock = model.Stock,
                ImageUrl = model.ImageUrl,
                CategorieId = model.CategorieId
            };

            await _produitRepository.CreateAsync(produit);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produit = await _produitRepository.GetByIdAsync(id);
            if (produit == null) return NotFound();

            var model = new EditProduitViewModels
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Description = produit.Description,
                Prix = produit.Prix,
                Stock = produit.Stock,
                ImageUrl = produit.ImageUrl,
                CategorieId = produit.CategorieId,
                Categorie = produit.Categorie
            };

            // Si besoin de liste de catégories pour un <select>
            ViewBag.Categories = new SelectList(await _categorieRepository.GetAllAsync(), "Id", "Nom");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProduitViewModels model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(await _categorieRepository.GetAllAsync(), "Id", "Nom");
                return View(model);
            }

            var produit = new Produit
            {
                Id = model.Id,
                Nom = model.Nom,
                Description = model.Description,
                Prix = model.Prix,
                Stock = model.Stock,
                ImageUrl = model.ImageUrl,
                CategorieId = model.CategorieId
            };

            await _produitRepository.UpdateAsync(produit);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Produit/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var produit = await _produitRepository.GetByIdAsync(id);
            if (produit == null) return NotFound();
            return View(produit); // On affiche les détails à confirmer
        }

        // POST: /Produit/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _produitRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
