
namespace ecommerce.Models.Domain
{
    public class Produit
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public decimal Prix { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public int CategorieId { get; set; }
        public virtual Categorie? Categorie { get; set; }
        public virtual ICollection<CommandeItem>? CommandeItems { get; set; }
        public virtual ICollection<PanierItem>? PanierItems { get; set; }
    }
}