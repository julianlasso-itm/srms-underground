import { Routes } from '@angular/router';

export const securityRoutes: Routes = [
  {
    path: 'sign-up',
    loadComponent: () =>
      import('./sign-up/page/sign-up.component').then((m) => m.SignUpComponent),
  },
  {
    path: 'sign-in',
    loadComponent: () =>
      import('./sign-in/page/sign-in.component').then((m) => m.SignInComponent),
  },
  {
    path: 'forgot-password',
    loadComponent: () =>
      import('./forgot-password/page/forgot-password.component').then(
        (m) => m.ForgotPasswordComponent
      ),
  },
  {
    path: 'reset-password/:token',
    loadComponent: () =>
      import('./reset-password/page/reset-password.component').then(
        (m) => m.ResetPasswordComponent
      ),
  },
  {
    path: 'verify-email/:token',
    loadComponent: () =>
      import('./verify-email/page/verify-email.component').then(
        (m) => m.VerifyEmailComponent
      ),
  },
  {
    path: 'sign-out',
    loadComponent: () =>
      import('./sign-out/sign-out.component').then((m) => m.SignOutComponent),
  },
];
