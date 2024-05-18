import { Routes } from '@angular/router';

export const userRoutes: Routes = [
  {
    path: 'profile',
    loadComponent: () =>
      import('./profile/profile.component').then((m) => m.ProfileComponent),
  },
];
