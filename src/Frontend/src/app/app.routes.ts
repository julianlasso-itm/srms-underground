import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './modules/shared/guards/auth.guard';
import { authInverterGuard } from './modules/shared/guards/auth-inverter.guard';

const routes: Routes = [
  {
    path: 'admin',
    canActivateChild: [authGuard],
    loadChildren: () =>
      import('./modules/admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: 'profiles',
    canActivateChild: [authGuard],
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
    canActivateChild: [authGuard],
    loadChildren: () =>
      import('./modules/user/user.module').then((m) => m.UserModule),
  },
  {
    path: 'home',
    canActivate: [authGuard],
    loadComponent: () =>
      import('./modules/home/home.component').then((m) => m.HomeComponent),
  },
  {
    path: '',
    canActivate: [authInverterGuard],
    loadComponent: () =>
      import('./modules/start/index/start.component').then(
        (m) => m.StartComponent
      ),
  },
  {
    path: 'assessment',
    canActivateChild: [authGuard],
    loadChildren: () =>
      import('./modules/assessment/assessment.module').then(
        (m) => m.AssessmentModule
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
