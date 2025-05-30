namespace ecommerce.Models.Domain
{
    public class PanierItem
    {
        public int Id { get; set; }

        public int UtilisateurId { get; set; }
        public virtual User? Utilisateur { get; set; }

        public int ProduitId { get; set; }
        public virtual Produit? Produit { get; set; }

        public int Quantite { get; set; }
    }
}