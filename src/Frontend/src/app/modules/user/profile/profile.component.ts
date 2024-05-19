import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatFormField, MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { StoreService } from '../../shared/services/store.service';
import { TokenDto } from '../../security/sign-in/modal/token.dto';
import { ProfileModel } from './profile.dto';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  selector: 'srms-profile',
  standalone: true,
  imports: [
    FormsModule,
    MatButtonModule,
    MatDividerModule,
    MatFormField,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
  ],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent implements OnInit{
  public profile!: ProfileModel;

  private token: string = '';

  /**
   *
   */
  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.profile = this.authService.getTokenData();
  }
}
