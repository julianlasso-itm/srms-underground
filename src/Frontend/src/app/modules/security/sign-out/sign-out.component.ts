import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../shared/services/auth.service';
import { Router } from '@angular/router';
import { StoreService } from '../../shared/services/store.service';

@Component({
  selector: 'srms-sign-out',
  standalone: true,
  imports: [],
  template: '',
})
export class SignOutComponent implements OnInit {
  constructor(
    private readonly _authService: AuthService,
    private readonly _router: Router,
    private readonly _storeService: StoreService
  ) {
    this._authService.signOut();
    this._storeService.clearToken();
    this._router.navigate(['./']);
  }

  ngOnInit(): void {
    // this._authService.signOut();
    // this._storeService.clearToken();
    // this._router.navigate(['./']);
  }
}
