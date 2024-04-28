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
  {
    path: 'cities',
    loadChildren: () =>
      import('./cities/cities.module').then((m) => m.CitiesModule),
  },
  {
    path: 'roles',
    loadChildren: () =>
      import('./roles/roles.module').then((m) => m.RolesModule),
  },
];
