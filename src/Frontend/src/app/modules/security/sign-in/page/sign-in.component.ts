import { Component, OnDestroy, OnInit } from '@angular/core';
import { SignInModalComponent } from '../modal/sign-in-modal.component';
import {
  MatDialog,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { AuthService } from '../../../shared/services/auth.service';

@Component({
  selector: 'srms-sign-in',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.scss',
})
export class SignInComponent implements OnInit, OnDestroy {
  private dialogRef!: MatDialogRef<SignInModalComponent>;

  constructor(
    private dialog: MatDialog,
    private readonly authService: AuthService
  ) {}

  ngOnInit(): void {
    this.dialogRef = this.dialog.open(SignInModalComponent, {
      width: '450px',
      disableClose: true,
    });
  }

  ngOnDestroy(): void {
    if (this.authService.isAuthenticated()) {
      this.dialogRef.close();
    }
  }
}
