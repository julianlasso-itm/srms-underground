import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../shared/services/auth.service';
import { StoreService } from '../../shared/services/store.service';

@Component({
    selector: 'srms-sign-out',
    standalone: true,
    imports: [],
    template: '',
})
export class SignOutComponent {
    constructor(
        private readonly _authService: AuthService,
        private readonly _router: Router,
        private readonly _storeService: StoreService
    ) {
        this._authService.signOut();
        this._storeService.clearToken();
        this._router.navigate(['./']);
    }
}
