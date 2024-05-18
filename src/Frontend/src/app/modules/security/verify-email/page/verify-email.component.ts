import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { VerifyEmailModalComponent } from '../modal/verify-email-modal.component';

@Component({
  selector: 'srms-verify-email',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './verify-email.component.html',
  styleUrl: './verify-email.component.scss',
})
export class VerifyEmailComponent implements OnInit, OnDestroy {
  private dialogRef!: MatDialogRef<VerifyEmailModalComponent>;

  constructor(private dialog: MatDialog) {}

  ngOnInit(): void {
    this.dialogRef = this.dialog.open(VerifyEmailModalComponent, {
      width: '450px',
      disableClose: true,
    });
  }

  ngOnDestroy(): void {
    this.dialogRef.close();
  }
}
