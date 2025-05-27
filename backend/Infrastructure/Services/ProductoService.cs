using Application.Interfaces;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodos() =>
            await _context.Productos.ToListAsync();

        public async Task<Producto?> ObtenerPorId(int id) =>
            await _context.Productos.FindAsync(id);

        public async Task CrearProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarProducto(Producto producto)
        {
            var productoExistente = await _context.Productos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == producto.Id);
            
            if (productoExistente == null) 
                throw new Exception("El producto no existe.");

            _context.Update(producto); // 🔹 Se reemplaza Entry() por Update()
            await _context.SaveChangesAsync();
        }

        public async Task EliminarProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}