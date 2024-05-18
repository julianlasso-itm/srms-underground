import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { ResetPasswordModalComponent } from '../modal/reset-password-modal.component';

@Component({
  selector: 'srms-reset-password',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './reset-password.component.html',
  styleUrl: './reset-password.component.scss',
})
export class ResetPasswordComponent implements OnInit, OnDestroy {
  private dialogRef!: MatDialogRef<ResetPasswordModalComponent>;

  constructor(private dialog: MatDialog) {}

  ngOnInit(): void {
    this.dialogRef = this.dialog.open(ResetPasswordModalComponent, {
      width: '450px',
      disableClose: true,
    });
  }

  ngOnDestroy(): void {
    this.dialogRef.close();
  }
}
