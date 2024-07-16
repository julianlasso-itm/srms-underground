import { Routes } from '@angular/router';

export const routesDashboard: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('../modules/home/home.component').then((m) => m.HomeComponent),
  },
];
