import { Routes } from '@angular/router';

export const assesmentsRoutes: Routes = [
    {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full',
    },
    {
        path: 'list',
        loadComponent: () =>
            import('./assesment/assesment.component').then((m) => m.AssesmentComponent),
    },
    {
        path: 'list/:id',
        loadComponent: () =>
            import('./assesment/assesment.component').then((m) => m.AssesmentComponent),
    },
];
