using System.Collections.Generic;
using CatalogoWeb.Entities;

namespace CatalogoWeb.Business
{
    public interface IContenidoService
    {
        List<Contenido> ObtenerTodos();
        List<Contenido> Buscar(string titulo, TipoContenido? tipo, string genero);
        Contenido ObtenerPorId(int id);
        List<string> Registrar(Contenido contenido);
        List<string> Editar(Contenido contenido);
        List<string> Eliminar(int id);
        void CambiarEstado(int id, EstadoContenido estado);
        EstadisticasContenido ObtenerEstadisticas();
    }
}