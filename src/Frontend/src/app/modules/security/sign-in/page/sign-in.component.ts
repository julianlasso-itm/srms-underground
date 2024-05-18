import { Component, OnDestroy, OnInit } from '@angular/core';
import { SignInModalComponent } from '../modal/sign-in-modal.component';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'srms-sign-in',
  standalone: true,
  imports: [
    MatDialogModule,
  ],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.scss',
})
export class SignInComponent implements OnInit, OnDestroy {
  private dialogRef!: MatDialogRef<SignInModalComponent>;

  constructor(private dialog: MatDialog) {}

  ngOnInit(): void {
    this.dialogRef = this.dialog.open(SignInModalComponent, {
      width: '450px',
      disableClose: true,
    });
  }

  ngOnDestroy(): void {
    this.dialogRef.close();
  }
}
