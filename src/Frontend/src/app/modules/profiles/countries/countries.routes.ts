import { Routes } from '@angular/router';

export const countriesRoutes: Routes = [
    {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full',
    },
    {
        path: 'list',
        loadComponent: () =>
            import('./country/country.component').then(
                (m) => m.CountryComponent
            ),
    },
];
