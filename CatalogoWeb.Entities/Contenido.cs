using System;
using System.ComponentModel.DataAnnotations; // 1. Importamos la librería de validaciones

namespace CatalogoWeb.Entities
{
    public class Contenido
    {
        private int _calificacion;
        
        public int Id { get; set; }

        // El título no puede estar vacío y limitamos su tamaño en la Base de Datos
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(20, ErrorMessage = "El título no puede exceder los 20 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Debes seleccionar un tipo.")]
        public TipoContenido Tipo { get; set; } 

        [Required(ErrorMessage = "El género es obligatorio.")]
        public GeneroContenido Genero { get; set; }

        // Validamos que el año sea realista (desde la primera película de la historia hasta el futuro cercano)
        [Required(ErrorMessage = "El año de estreno es obligatorio.")]
        [Range(1888, 2026, ErrorMessage = "Por favor, ingresa un año válido entre 1888 y 2026.")]
        public int AnioEstreno { get; set; }

        [Required(ErrorMessage = "La plataforma es obligatoria.")]
        public PlataformaContenido Plataforma { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public EstadoContenido Estado { get; set; }

        // La reseña es opcional, pero si escribe algo, limitamos los caracteres
        [StringLength(500, ErrorMessage = "La reseña no puede tener más de 500 caracteres.")]
        public string Resena { get; set; }

        // 2. Agregamos el rango aquí para que el formulario web lo valide de forma amigable
        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
        public int Calificacion
        {
            get => _calificacion;
            set
            {
                // Mantenemos tu validación de negocio. 
                // Ahora está doblemente protegido: por la interfaz web y por la clase misma.
                if (value < 1 || value > 5)
                    throw new ArgumentOutOfRangeException(nameof(value), "La calificación debe estar entre 1 y 5.");
                _calificacion = value;
            }
        }

        public Contenido() { }

        public Contenido(string titulo, TipoContenido tipo, GeneroContenido genero, int anioEstreno,
                          PlataformaContenido plataforma, EstadoContenido estado, int calificacion, string resena)
        {
            Titulo = titulo;
            Tipo = tipo;
            Genero = genero;
            AnioEstreno = anioEstreno;
            Plataforma = plataforma;
            Estado = estado;
            Calificacion = calificacion;
            Resena = resena;
        }

        public void MarcarComoVisto() => Estado = EstadoContenido.Vista;
        public void MarcarComoPendiente() => Estado = EstadoContenido.Pendiente;

        public override string ToString() => $"{Titulo} ({AnioEstreno}) - {Tipo}";
    }
}