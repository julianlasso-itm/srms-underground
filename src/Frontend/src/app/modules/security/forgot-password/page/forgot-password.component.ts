import { Component, OnDestroy, OnInit } from '@angular/core';
import {
    MatDialog,
    MatDialogModule,
    MatDialogRef,
} from '@angular/material/dialog';
import { ForgotPasswordModalComponent } from '../modal/forgot-password-modal.component';

@Component({
    selector: 'srms-forgot-password',
    standalone: true,
    imports: [MatDialogModule],
    templateUrl: './forgot-password.component.html',
    styleUrl: './forgot-password.component.scss',
})
export class ForgotPasswordComponent implements OnInit, OnDestroy {
    private dialogRef!: MatDialogRef<ForgotPasswordModalComponent>;

    constructor(private dialog: MatDialog) {}

    ngOnInit(): void {
        this.dialogRef = this.dialog.open(ForgotPasswordModalComponent, {
            width: '450px',
            disableClose: true,
        });
    }

    ngOnDestroy(): void {
        this.dialogRef.close();
    }
}
