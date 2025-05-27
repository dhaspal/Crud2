import { Routes } from '@angular/router';


export const appRoutes: Routes = [
  { path: '', redirectTo: '/productos', pathMatch: 'full' },
  { path: 'productos', loadComponent: () => import('./features/producto/producto.component').then(m => m.ProductoComponent) },
  { path: '**', redirectTo: '/productos' }
];