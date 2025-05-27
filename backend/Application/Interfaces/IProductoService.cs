using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> ObtenerTodos();
        Task<Producto?> ObtenerPorId(int id);
        Task CrearProducto(Producto producto);
        Task ActualizarProducto(Producto producto);
        Task EliminarProducto(int id);
    }
}