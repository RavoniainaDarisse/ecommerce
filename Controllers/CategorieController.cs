using ecommerce.Models.Domain;
using ecommerce.Models.ViewModels;
using ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ecommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategorieController : Controller
    {
        private readonly ICategorieRepository _categorieService;

        public CategorieController(ICategorieRepository categorieService)
        {
            _categorieService = categorieService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categorieService.GetAllAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCategorieViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var categorie = new Categorie
            {
                Nom = model.Nom
            };

            await _categorieService.CreateAsync(categorie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categorie = await _categorieService.GetByIdAsync(id);
            if (categorie == null) return NotFound();

            var viewModel = new EditCategorieViewModel
            {
                Id = categorie.Id,
                Nom = categorie.Nom
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategorieViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var categorie = new Categorie
            {
                Id = model.Id,
                Nom = model.Nom
            };

            await _categorieService.UpdateAsync(categorie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categorie = await _categorieService.GetByIdAsync(id);
            return categorie == null ? NotFound() : View(categorie);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categorieService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}