import { Routes } from '@angular/router';

export const rolesRoutes: Routes = [
    {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full',
    },
    {
        path: 'list',
        loadComponent: () =>
            import('./role/role.component').then((m) => m.RoleComponent),
    },
];
