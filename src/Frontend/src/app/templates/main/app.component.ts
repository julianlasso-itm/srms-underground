import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../modules/shared/services/auth.service';
import { ProfileComponent } from '../../modules/user/profile/profile.component';
import { StoreService } from '../../modules/shared/services/store.service';
import { ProfileModel } from '../../modules/user/profile/profile.dto';
import { Constant } from '../../modules/shared/constants/constants';

@Component({
  selector: 'srms-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  isAuth: boolean;
  isAdmin: boolean;
  private authObservable!: Subscription;
  public profile: ProfileModel = new ProfileModel();

  constructor(private authService: AuthService, private route: Router) {
    this.isAuth = this.authService.isAuthenticated();
    this.profile = this.authService.getTokenData();
    this.isAdmin = this.validateAdmin();
  }
  
  ngOnInit() {
    this.authObservable = this.authService.isAuthSubject.subscribe((isAuth) => {
      this.isAuth = isAuth;
    });
  }

  validateAdmin(): boolean {
    return this.profile.Roles.includes(Constant.ADMIN_ROLE);
  }
}



