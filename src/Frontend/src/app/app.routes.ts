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
  {
    path: 'security',
    loadChildren: () =>
      import('./modules/security/security.module').then(
        (m) => m.SecurityModule
      ),
  },
  {
    path: 'user',
    loadChildren: () =>
      import('./modules/user/user.module').then((m) => m.UserModule),
  },
  // { path: '**', redirectTo: 'not-found' },
];
