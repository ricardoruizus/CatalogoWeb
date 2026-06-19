using System.ComponentModel.DataAnnotations;

namespace CatalogoWeb.Entities
{
    public enum PlataformaContenido
    {
        [Display(Name = "Netflix")]
        Netflix,
        [Display(Name = "Amazon Prime Video")]
        AmazonPrime,
        [Display(Name = "Max (HBO)")]
        Max,
        [Display(Name = "Disney+")]
        DisneyPlus,
        [Display(Name = "Apple TV+")]
        AppleTV,
        Crunchyroll,
        Cine,
        [Display(Name = "Televisión Abierta")]
        TV,
        Otra
    }
}