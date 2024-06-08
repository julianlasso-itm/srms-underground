import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { PodiumComponent } from '../podium/podium.component';
import { BannerComponent } from '../banner/banner.component';
import { AuthService } from '../../shared/services/auth.service';
import { AvatarService } from '../../shared/services/avatar.service';
import { NameService } from '../../shared/services/name.service';
import { Subscription } from 'rxjs';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'srms-index',
  standalone: true,
  imports: [
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatToolbarModule,
    MatButtonModule,
    CommonModule,
    PodiumComponent,
    BannerComponent,
    RouterModule
  ],
  templateUrl: './start.component.html',
  styleUrl: './start.component.scss',
})
export class StartComponent {
  private authObservable!: Subscription;
  isAuth: boolean;
  avatar: string;
  name: string;

  constructor(
    private authService: AuthService,
    private avatarService: AvatarService,
    private nameService: NameService
  ) {
    this.isAuth = this.authService.isAuthenticated();
    this.avatar = this.avatarService.get();
    this.name = this.nameService.get();
  }
  
  ngOnInit() {
    this.authObservable = this.authService.isAuthSubject.subscribe((isAuth) => {
      this.isAuth = isAuth;
    });
    this.avatarService.avatarSubject.subscribe((avatar) => {
      this.avatar = avatar;
    });
    this.nameService.nameSubject.subscribe((name) => {
      this.name = name;
    });
  }
}
