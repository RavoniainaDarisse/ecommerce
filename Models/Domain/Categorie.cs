namespace ecommerce.Models.Domain
{
    public class Categorie
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public virtual ICollection<Produit>? Produits { get; set; }
    }
}