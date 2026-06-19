using System.Collections.Generic;
using System.Linq;
using CatalogoWeb.Entities;

namespace CatalogoWeb.Data
{
    // Implementación en memoria. Se registra como Singleton en Program.cs
    // para que la lista persista mientras la app esté corriendo.
    public class ContenidoRepository : IContenidoRepository
    {
        private readonly List<Contenido> _datos = new();
        private int _siguienteId = 1;

        public ContenidoRepository()
        {
            // Datos de ejemplo para que el catálogo no inicie vacío
            Agregar(new Contenido("Breaking Bad", TipoContenido.Serie, GeneroContenido.Drama, 2008, PlataformaContenido.Netflix, EstadoContenido.Vista, 5, "Una obra maestra."));
            Agregar(new Contenido("Inception", TipoContenido.Pelicula, GeneroContenido.CienciaFiccion, 2010, PlataformaContenido.Max, EstadoContenido.Pendiente, 4, "Pendiente de ver."));
        }

        public List<Contenido> ObtenerTodos() => _datos.ToList();

        public Contenido ObtenerPorId(int id) => _datos.FirstOrDefault(c => c.Id == id);

        public bool Existe(int id) => _datos.Any(c => c.Id == id);

        public void Agregar(Contenido contenido)
        {
            contenido.Id = _siguienteId++;
            _datos.Add(contenido);
        }

        public void Actualizar(Contenido contenido)
        {
            var existente = ObtenerPorId(contenido.Id);
            if (existente == null) return;

            existente.Titulo = contenido.Titulo;
            existente.Tipo = contenido.Tipo;
            existente.Genero = contenido.Genero;
            existente.AnioEstreno = contenido.AnioEstreno;
            existente.Plataforma = contenido.Plataforma;
            existente.Estado = contenido.Estado;
            existente.Calificacion = contenido.Calificacion;
            existente.Resena = contenido.Resena;
        }

        public void Eliminar(int id)
        {
            var existente = ObtenerPorId(id);
            if (existente != null) _datos.Remove(existente);
        }
    }
}