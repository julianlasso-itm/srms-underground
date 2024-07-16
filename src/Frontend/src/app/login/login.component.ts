import { Component, OnInit } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth-google.service';

@Component({
  selector: 'srms-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  profile: unknown;

  constructor(
    private authService: AuthService,
    private route: Router,
    private iconRegistry: MatIconRegistry,
    private sanitizer: DomSanitizer
  ) {
    this.authService = authService;
    this.iconRegistry.addSvgIcon(
      'google',
      this.sanitizer.bypassSecurityTrustResourceUrl('icons/google.svg')
    );
  }

  ngOnInit(): void {
    this.profile = this.authService.getProfile();
    if (this.profile) {
      this.route.navigate(['/dashboard']);
    }
  }

  signIn(): void {
    this.authService.login();
  }
}
