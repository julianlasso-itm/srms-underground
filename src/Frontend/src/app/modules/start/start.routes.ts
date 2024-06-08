import { Routes } from '@angular/router';

export const startRoutes: Routes = [
    {
        path: '',
        pathMatch: 'full',
    },
    {
        path: '',
        loadComponent: () =>
            import('./index/start.component').then((m) => m.StartComponent),
    },
];
