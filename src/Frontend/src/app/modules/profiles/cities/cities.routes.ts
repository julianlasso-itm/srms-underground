import { Routes } from '@angular/router';

export const citiesRoutes: Routes = [
  {
    path: '',
    redirectTo: 'list',
    pathMatch: 'full',
  },
  {
    path: 'list',
    loadComponent: () =>
      import('./city/city.component').then((m) => m.CityComponent),
  },
  {
    path: 'list/:id',
    loadComponent: () =>
      import('./city/city.component').then((m) => m.CityComponent),
  },
];
