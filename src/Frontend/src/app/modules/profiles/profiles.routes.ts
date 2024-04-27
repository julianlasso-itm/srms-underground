import { Routes } from '@angular/router';

export const profilesRoutes: Routes = [
  {
    path: 'countries',
    loadChildren: () =>
      import('./countries/countries.module').then((m) => m.CountriesModule),
  },
  {
    path: 'provinces',
    loadChildren: () =>
      import('./provinces/provinces.module').then((m) => m.ProvincesModule),
  },
];
