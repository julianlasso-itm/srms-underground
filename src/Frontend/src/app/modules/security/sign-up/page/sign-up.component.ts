import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { SignUpModalComponent } from '../modal/sign-up-modal.component';

@Component({
  selector: 'srms-sign-up',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss',
})
export class SignUpComponent implements OnInit, OnDestroy {
  private dialogRef!: MatDialogRef<SignUpModalComponent>;

  constructor(private dialog: MatDialog) {}

  ngOnInit(): void {
    this.dialogRef = this.dialog.open(SignUpModalComponent, {
      width: '900px',
      disableClose: true,
    });
  }

  ngOnDestroy(): void {
    this.dialogRef.close();
  }
}
