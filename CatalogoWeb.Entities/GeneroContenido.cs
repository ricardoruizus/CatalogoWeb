using System.ComponentModel.DataAnnotations;

namespace CatalogoWeb.Entities
{
    public enum GeneroContenido
    {
        [Display(Name = "Acción")]
        Accion,
        Comedia,
        Drama,
        [Display(Name = "Ciencia Ficción")]
        CienciaFiccion,
        Terror,
        Romance,
        Documental,
        Animacion,
        Otro
    }
}