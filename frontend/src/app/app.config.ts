import { provideRouter, withEnabledBlockingInitialNavigation } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { appRoutes } from './app.routes'; // 📌 Importar las rutas correctamente

export const appConfig = {
  providers: [
    provideRouter(appRoutes, withEnabledBlockingInitialNavigation()),
    provideHttpClient() // 🔥 Nueva forma de proporcionar HttpClient
  ]
};