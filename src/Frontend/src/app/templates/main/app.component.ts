import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../modules/shared/services/auth.service';

@Component({
  selector: 'srms-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  isAuth: boolean;
  private authObservable!: Subscription;

  constructor(private authService: AuthService, private route: Router) {
    this.isAuth = this.authService.isAuthenticated();
  }

  ngOnInit() {
    this.authObservable = this.authService.isAuthSubject.subscribe((isAuth) => {
      this.isAuth = isAuth;
      if (!isAuth) {
        this.route.navigate(['./security/sign-in']);
      }
    });
  }
}
