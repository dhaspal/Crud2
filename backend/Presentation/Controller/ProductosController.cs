using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Interfaces;
using Core.Entities;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductos() => Ok(await _productoService.ObtenerTodos());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductoById(int id)
    {
        var producto = await _productoService.ObtenerPorId(id);
        return producto == null ? NotFound() : Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProducto([FromBody] Producto producto)
    {
        await _productoService.CrearProducto(producto);
        return CreatedAtAction(nameof(GetProductoById), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProducto(int id, [FromBody] Producto producto)
    {
        if (producto == null) return BadRequest("El cuerpo de la solicitud es inválido.");
        if (id != producto.Id) return BadRequest("El ID en la URL no coincide con el ID en el cuerpo.");

        try
        {
            await _productoService.ActualizarProducto(producto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al actualizar el producto: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        await _productoService.EliminarProducto(id);
        return NoContent();
    }
}