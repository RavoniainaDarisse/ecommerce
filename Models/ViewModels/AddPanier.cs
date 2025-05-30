namespace ecommerce.Models.ViewModels;

public class AddPanier
{
    public int UtilisateurId { get; set; }
    public int ProduitId { get; set; }
    public int Quantite { get; set; } = 0;
}
