import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../modules/shared/services/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { SignUpComponent } from '../../modules/security/sign-up/sign-up.component';

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
  ],
  providers: [],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  isAuth = false;
  private authObservable!: Subscription;

  constructor(
    private authService: AuthService,
    private route: Router,
    private dialog: MatDialog
  ) {}

  ngOnInit() {
    this.authObservable = this.authService.isAuth.subscribe((isAuth) => {
      this.isAuth = isAuth;
      if (!isAuth) {
        this.route.navigate(['/']);
      }
    });
    if (!this.isAuth) {
      this.dialog.open(SignUpComponent, {
        width: '450px',
        disableClose: true,
      });
    }
  }
}
