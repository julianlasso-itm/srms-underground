import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../modules/shared/services/auth.service';
import { ProfileModel } from '../../modules/user/profile/profile.dto';
import { Constant } from '../../modules/shared/constants/constants';
import { StoreService } from '../../modules/shared/services/store.service';

@Component({
  selector: 'srms-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  isAuth: boolean;
  private authObservable!: Subscription;

  constructor(private authService: AuthService) {
    this.isAuth = this.authService.isAuthenticated();
  }

  ngOnInit() {
    this.authObservable = this.authService.isAuthSubject.subscribe((isAuth) => {
      this.isAuth = isAuth;
    });
  }

  getProfile() {
    return this.authService.getUserAutenticated();
  }

  isAdmin(): boolean {
    return this.authService
      .getUserAutenticated()
      .Roles.includes(Constant.ADMIN_ROLE);
  }
}
