import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Producto } from '../../core/models/producto.model'; // Asegúrate de importar correctamente tu modelo

@Injectable({
  providedIn: 'root' // Disponible en toda la aplicación
})
export class ProductoService {
  private apiUrl = 'http://localhost:5059/api/productos'; // URL de la API
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {}

  // 🔹 Obtener todos los productos
  getProductos(): Observable<Producto[]> {
    return this.http.get<Producto[]>(this.apiUrl);
  }

  // 🔹 Obtener un producto por ID
  getProductoById(id: number): Observable<Producto> {
    return this.http.get<Producto>(`${this.apiUrl}/${id}`);
  }

  // 🔹 Crear un producto (POST)
  createProducto(producto: Producto): Observable<Producto> {
    return this.http.post<Producto>(this.apiUrl, producto, this.httpOptions);
  }

  // 🔹 Actualizar un producto (PUT)
  updateProducto(producto: Producto): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${producto.id}`, producto, this.httpOptions);
  }

  // 🔹 Eliminar un producto (DELETE)
  deleteProducto(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}