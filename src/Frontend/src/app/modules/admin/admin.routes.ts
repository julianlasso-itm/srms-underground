import { Routes } from '@angular/router';

export const adminRoutes: Routes = [
  {
    path: 'roles',
    loadChildren: () =>
      import('./roles/roles.module').then((m) => m.RolesModule),
  },
];
