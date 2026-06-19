using System.Collections.Generic;
using System.Linq;
using CatalogoWeb.Entities;
using Microsoft.EntityFrameworkCore;


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
            // 1. Buscamos si EF ya tiene guardado en memoria algo con ese mismo Id
            var local = _context.Contenidos
            .Local
            .FirstOrDefault(entry => entry.Id == contenido.Id);

            // 2. Si lo encuentra, le decimos que se despegue (Detached) para liberar el Id
            if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

            // 3. Ahora que el Id está libre en memoria, actualizamos y guardamos
            _context.Contenidos.Update(contenido);
            _context.SaveChanges(); // Asegúrate de que tenga el SaveChanges() para guardar en la base de datos
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