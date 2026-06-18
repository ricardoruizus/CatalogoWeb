using System.Collections.Generic;
using System.Linq;
using CatalogoWeb.Entities;

namespace CatalogoWeb.Data
{
    public class ContenidoSqlRepository : IContenidoRepository
    {
        private readonly DataContext _context;

        public ContenidoSqlRepository(DataContext context)
        {
            _context = context;
        }

        public List<Contenido> ObtenerTodos()
        {
            return _context.Contenidos.ToList();
        }

        public Contenido? ObtenerPorId(int id)
        {
            return _context.Contenidos.FirstOrDefault(c => c.Id == id);
        }

        public bool Existe(int id)
        {
            return _context.Contenidos.Any(c => c.Id == id);
        }

        public void Agregar(Contenido contenido)
        {
            _context.Contenidos.Add(contenido);
            _context.SaveChanges(); 
        }

        public void Actualizar(Contenido contenido)
        {
            _context.Contenidos.Update(contenido);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var existente = ObtenerPorId(id);
            if (existente != null)
            {
                _context.Contenidos.Remove(existente);
                _context.SaveChanges();
            }
        }
    }
}