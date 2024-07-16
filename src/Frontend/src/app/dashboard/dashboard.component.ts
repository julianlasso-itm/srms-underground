import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { Subscription } from 'rxjs';

import { AuthService } from '../services/auth-google.service';
import { AuthStorageService } from '../services/auth-storage.service';

import { MatDividerModule } from '@angular/material/divider';

import { HeaderComponent } from './header/header.component';
import { MenuIconComponent } from './menu-icon/menu-icon.component';
import { MenuComponent } from './menu/menu.component';

@Component({
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    MatDividerModule,
    MenuIconComponent,
    MenuComponent,
    HeaderComponent,
  ],
  selector: 'srms-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent implements OnInit, OnDestroy {
  public profile: Record<string, unknown> = {};
  private storageService: Subscription = new Subscription();

  constructor(
    private authService: AuthService,
    private router: Router,
    private authStorageService: AuthStorageService
  ) {}

  ngOnInit(): void {
    this.storageService = this.authStorageService
      .getItemObservable()
      .subscribe({
        next: (data: Map<string, string>) => {
          if (data.has('id_token_claims_obj')) {
            this.showData();
          }
        },
      });
    this.showData();
  }

  ngOnDestroy(): void {
    this.storageService.unsubscribe();
  }

  showData(): void {
    this.profile = this.authService.getProfile();
  }

  logOut(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
