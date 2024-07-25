import { Routes } from '@angular/router';

export const routesDashboard: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('../home/home.component').then((m) => m.HomeComponent),
  },
];
