using System;
using System.Collections.Generic;
using System.Linq;
using CatalogoWeb.Data;
using CatalogoWeb.Entities;

namespace CatalogoWeb.Business
{
    // Aquí viven las reglas de negocio. El controlador nunca decide
    // si un registro es válido: solo le pregunta a este servicio.
    public class ContenidoService : IContenidoService
    {
        private readonly IContenidoRepository _repositorio;

        public ContenidoService(IContenidoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Contenido> ObtenerTodos() => _repositorio.ObtenerTodos();

        public Contenido ObtenerPorId(int id) => _repositorio.ObtenerPorId(id);

        public List<Contenido> Buscar(string titulo, TipoContenido? tipo, string genero)
        {
            var resultado = _repositorio.ObtenerTodos();

            if (!string.IsNullOrWhiteSpace(titulo))
                resultado = resultado.Where(c => c.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)).ToList();

            if (tipo.HasValue)
                resultado = resultado.Where(c => c.Tipo == tipo.Value).ToList();

            if (!string.IsNullOrWhiteSpace(genero))
                resultado = resultado.Where(c => c.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase)).ToList();

            return resultado;
        }

        public List<string> Registrar(Contenido contenido)
        {
            var errores = ValidarReglasComunes(contenido);

            bool duplicado = _repositorio.ObtenerTodos().Any(c =>
                c.Titulo.Equals(contenido.Titulo, StringComparison.OrdinalIgnoreCase) && c.Tipo == contenido.Tipo);

            if (duplicado) errores.Add("Ya existe un registro con ese título y tipo.");
            if (errores.Count == 0) _repositorio.Agregar(contenido);

            return errores;
        }

        public List<string> Editar(Contenido contenido)
        {
            var errores = ValidarReglasComunes(contenido);

            if (!_repositorio.Existe(contenido.Id))
            {
                errores.Add("No se puede editar un registro que no existe.");
                return errores;
            }

            bool duplicado = _repositorio.ObtenerTodos().Any(c =>
                c.Id != contenido.Id &&
                c.Titulo.Equals(contenido.Titulo, StringComparison.OrdinalIgnoreCase) && c.Tipo == contenido.Tipo);

            if (duplicado) errores.Add("Ya existe otro registro con ese título y tipo.");
            if (errores.Count == 0) _repositorio.Actualizar(contenido);

            return errores;
        }

        public List<string> Eliminar(int id)
        {
            var errores = new List<string>();

            if (!_repositorio.Existe(id))
            {
                errores.Add("No se puede eliminar un registro que no existe.");
                return errores;
            }

            _repositorio.Eliminar(id);
            return errores;
        }

        public void CambiarEstado(int id, EstadoContenido estado)
        {
            var contenido = _repositorio.ObtenerPorId(id);
            if (contenido == null) return;

            if (estado == EstadoContenido.Vista) contenido.MarcarComoVisto();
            else contenido.MarcarComoPendiente();

            _repositorio.Actualizar(contenido);
        }

        public EstadisticasContenido ObtenerEstadisticas()
        {
            var todos = _repositorio.ObtenerTodos();

            return new EstadisticasContenido
            {
                Total = todos.Count,
                TotalPeliculas = todos.Count(c => c.Tipo == TipoContenido.Pelicula),
                TotalSeries = todos.Count(c => c.Tipo == TipoContenido.Serie),
                TotalVistas = todos.Count(c => c.Estado == EstadoContenido.Vista),
                TotalPendientes = todos.Count(c => c.Estado == EstadoContenido.Pendiente),
                PromedioCalificacion = todos.Count > 0 ? Math.Round(todos.Average(c => c.Calificacion), 2) : 0
            };
        }

        private List<string> ValidarReglasComunes(Contenido contenido)
        {
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(contenido.Titulo))
                errores.Add("El título no puede estar vacío.");

            if (contenido.AnioEstreno > DateTime.Now.Year)
                errores.Add($"El año no puede ser mayor a {DateTime.Now.Year}.");

            if (contenido.Calificacion < 1 || contenido.Calificacion > 5)
                errores.Add("La calificación debe estar entre 1 y 5.");

            return errores;
        }
    }
}