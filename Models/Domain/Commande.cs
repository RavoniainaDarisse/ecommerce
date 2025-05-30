namespace ecommerce.Models.Domain
{
    public class Commande
    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public virtual User? Utilisateur { get; set; }
        public DateTime DateCommande { get; set; }
        public decimal Total { get; set; }
        public string? Statut { get; set; } // "En cours", "Expédiée", "Livrée", etc.

        public virtual ICollection<CommandeItem>? CommandeItems { get; set; }
    }
}