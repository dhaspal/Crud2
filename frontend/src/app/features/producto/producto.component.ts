import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // 🔹 Importar FormsModule
import { ProductoService } from '../../core/services/producto.service';
import { Producto } from '../../core/models/producto.model';

@Component({
  selector: 'app-producto',
  standalone: true,
  templateUrl: './producto.component.html',
  imports: [CommonModule, FormsModule] // 🔥 Agregar FormsModule aquí
})
export class ProductoComponent {
  productos: Producto[] = [];
  productoSeleccionado: Producto | null = null;
  productoEditando = false;
  productoEditado: Producto = this.obtenerProductoVacio();

  constructor(private productoService: ProductoService) {}

  ngOnInit(): void {
    this.obtenerProductos();
  }

  obtenerProductoVacio(): Producto {
    return { id: 0, nombre: '', descripcion: '', precio: 0, stock: 0, fechaCreacion: new Date() };
  }

  obtenerProductos(): void {
    this.productoService.getProductos().subscribe((data) => {
      this.productos = data;
    });
  }

  seleccionarProducto(producto: Producto): void {
    this.productoSeleccionado = producto;
  }

  eliminarProducto(id: number): void {
    this.productoService.deleteProducto(id).subscribe(() => {
      this.productos = this.productos.filter(p => p.id !== id);
      this.productoSeleccionado = null;
    });
  }

  guardarProducto(): void {
    if (this.productoEditando) {
      this.productoService.updateProducto(this.productoEditado).subscribe(() => {
        this.obtenerProductos();
        this.cancelarEdicion();
      });
    } else {
      this.productoService.createProducto(this.productoEditado).subscribe((producto) => {
        this.productos.push(producto);
        this.productoEditado = this.obtenerProductoVacio();
      });
    }
  }

  editarProducto(producto: Producto): void {
    this.productoEditando = true;
    this.productoEditado = { ...producto };
  }

  cancelarEdicion(): void {
    this.productoEditando = false;
    this.productoEditado = this.obtenerProductoVacio();
  }
}