using System.Collections.Generic;
using CatalogoWeb.Entities;

namespace CatalogoWeb.Data
{
    // Abstracción: Business depende de esta interfaz, no de la implementación concreta.
    // Si luego quieren el extra de SQLite, solo crean otra clase que implemente esto.
    public interface IContenidoRepository
    {
        List<Contenido> ObtenerTodos();
        Contenido ObtenerPorId(int id);
        void Agregar(Contenido contenido);
        void Actualizar(Contenido contenido);
        void Eliminar(int id);
        bool Existe(int id);
    }
}