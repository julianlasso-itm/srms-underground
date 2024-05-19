import { Routes } from '@angular/router';

export const provincesRoutes: Routes = [
    {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full',
    },
    {
        path: 'list',
        loadComponent: () =>
            import('./province/province.component').then(
                (m) => m.ProvinceComponent
            ),
    },
    {
        path: 'list/:id',
        loadComponent: () =>
            import('./province/province.component').then(
                (m) => m.ProvinceComponent
            ),
    },
];
