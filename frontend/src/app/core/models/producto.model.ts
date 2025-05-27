export interface Producto {
  id: number;               // Identificador único del producto
  nombre: string;           // Nombre del producto
  descripcion: string;      // Descripción detallada del producto
  precio: number;           // Precio del producto
  stock: number;            // Cantidad disponible en inventario
  fechaCreacion: Date;      // Fecha en que se registró el producto
}