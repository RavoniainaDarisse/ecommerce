namespace ecommerce.Models.Domain
{
    public class User
    {
    public int Id { get; set; }
    public string? Nom { get; set; }
    public string? Email { get; set; }
    public string? MotDePasse { get; set; }
    public string? Adresse { get; set; }
    public string? Telephone { get; set; }
    public string? Role { get; set; } // "Client" ou "Admin"

    public virtual ICollection<Commande>? Commandes { get; set; }
    public virtual ICollection<PanierItem>? PanierItems { get; set; }
    }
}