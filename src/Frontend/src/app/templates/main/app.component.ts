import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../modules/shared/services/auth.service';

@Component({
  selector: 'srms-root',
  standalone: true,
  imports: [
    RouterOutlet,
    MatToolbarModule,
    MatCardModule,
    MatListModule,
    MatIconModule,
    RouterModule,
    MatDividerModule,
    MatMenuModule,
  ],
  providers: [],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  isAuth: boolean;
  private authObservable!: Subscription;

  constructor(private authService: AuthService, private route: Router) {
    this.isAuth = this.authService.isAuth;
  }

  ngOnInit() {
    this.authObservable = this.authService.isAuthSubject.subscribe((isAuth) => {
      this.isAuth = isAuth;
      if (!isAuth) {
        this.redirectToSignIn();
      }
    });
  }

  redirectToSignIn() {
    this.route.navigate(['./security/sign-in']);
  }
}
