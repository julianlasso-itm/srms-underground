import { inject } from '@angular/core';
import {
    ActivatedRouteSnapshot,
    CanActivateFn,
    Router,
    RouterStateSnapshot,
} from '@angular/router';
import { AuthService } from '../services/auth.service';
import { StoreService } from '../services/store.service';

export const authGuard: CanActivateFn = async (
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
        return true;
    } else {
        router.navigate(['./security/sign-in']);
        return false;
    }
};
