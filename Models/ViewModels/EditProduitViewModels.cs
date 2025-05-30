using ecommerce.Models.Domain;

namespace ecommerce.Models.ViewModels
{
    public class EditProduitViewModels
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public decimal Prix { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public int CategorieId { get; set; }
        public virtual Categorie? Categorie { get; set; }
    }
}