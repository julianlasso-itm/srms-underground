import { Routes } from '@angular/router';

export const professionalsRoutes: Routes = [
  {
    path: '',
    redirectTo: 'list',
    pathMatch: 'full',
  },
  {
    path: 'list',
    loadComponent: () =>
      import('./professional/professional.component').then((m) => m.ProfessionalComponent),
  },
];
