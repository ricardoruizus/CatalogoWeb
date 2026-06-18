using System;

namespace CatalogoWeb.Entities
{
    // Clase = el "molde". Cada registro del catálogo es un Objeto (una instancia) de esta clase.
    public class Contenido
    {
        // Encapsulamiento: el campo privado solo se puede modificar
        // a través de la propiedad Calificacion, que valida el rango.
        private int _calificacion;

        public int Id { get; set; }
        public string Titulo { get; set; }
        public TipoContenido Tipo { get; set; } // al ser enum, solo admite Serie o Pelicula
        public string Genero { get; set; }
        public int AnioEstreno { get; set; }
        public string Plataforma { get; set; }
        public EstadoContenido Estado { get; set; }
        public string Resena { get; set; }

        public int Calificacion
        {
            get => _calificacion;
            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentOutOfRangeException(nameof(value), "La calificación debe estar entre 1 y 5.");
                _calificacion = value;
            }
        }

        // Constructor vacío: lo necesita el model binding de ASP.NET Core
        public Contenido() { }

        // Constructor con parámetros: crea un objeto completo en una sola línea (útil para datos de prueba)
        public Contenido(string titulo, TipoContenido tipo, string genero, int anioEstreno,
                          string plataforma, EstadoContenido estado, int calificacion, string resena)
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

        // Métodos: comportamiento del objeto, no solo datos
        public void MarcarComoVisto() => Estado = EstadoContenido.Vista;
        public void MarcarComoPendiente() => Estado = EstadoContenido.Pendiente;

        public override string ToString() => $"{Titulo} ({AnioEstreno}) - {Tipo}";
    }
}