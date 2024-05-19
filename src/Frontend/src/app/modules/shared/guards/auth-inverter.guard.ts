import {
  ActivatedRouteSnapshot,
  CanActivateFn,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';
import { StoreService } from '../services/store.service';

export const authInverterGuard: CanActivateFn = async (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  const storeService = inject(StoreService);

  const token = storeService.getToken();
  if (token !== '' && token.length > 0) {
    await authService.verifyToken(token);
  }

  const isAuth = authService.isAuthenticated();
  if (isAuth) {
    console.log('authService.isAuthenticated()');
    router.navigate(['./home']);
    return false;
  } else {
    console.log('!authService.isAuthenticated()');
    return true;
  }
};
