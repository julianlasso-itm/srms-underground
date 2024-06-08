import { Routes } from '@angular/router';

export const squadsRoutes: Routes = [
    {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full',
    },
    {
        path: 'list',
        loadComponent: () =>
            import('./squad/squad.component').then((m) => m.SquadComponent),
    },
];
