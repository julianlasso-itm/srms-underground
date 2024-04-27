import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'admin',
    loadChildren: () =>
      import('./modules/admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: 'profiles',
    loadChildren: () =>
      import('./modules/profiles/profiles.module').then(
        (m) => m.ProfilesModule
      ),
  },
];
