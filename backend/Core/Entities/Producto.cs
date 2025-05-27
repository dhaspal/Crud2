

namespace Core.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Producto()
        {
            FechaCreacion = DateTime.UtcNow;
        }
    }
}