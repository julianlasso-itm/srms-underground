import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../modules/shared/services/auth.service';
import { ProfileModel } from '../../modules/user/profile/profile.dto';
import { Constant } from '../../modules/shared/constants/constants';
import { StoreService } from '../../modules/shared/services/store.service';
import { AvatarService } from '../../modules/shared/services/avatar.service';

@Component({
  selector: 'srms-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  isAuth: boolean;
  avatar: string;
  private authObservable!: Subscription;

  constructor(private authService: AuthService, private avatarService: AvatarService) {
    this.isAuth = this.authService.isAuthenticated();
    this.avatar = this.avatarService.get();
  }

  ngOnInit() {
    this.authObservable = this.authService.isAuthSubject.subscribe((isAuth) => {
      this.isAuth = isAuth;
    });
    this.avatarService.avatarSubject.subscribe((avatar) => {
      this.avatar = avatar;
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
