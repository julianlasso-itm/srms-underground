import { Component, OnDestroy, OnInit } from '@angular/core';
import {
    MatDialog,
    MatDialogModule,
    MatDialogRef,
} from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
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
    private token: string;

    constructor(
        private dialog: MatDialog,
        private readonly activatedRoute: ActivatedRoute
    ) {
        this.token = this.activatedRoute.snapshot.params['token'];
    }

    ngOnInit(): void {
        this.dialogRef = this.dialog.open(ResetPasswordModalComponent, {
            width: '450px',
            disableClose: true,
            data: { token: this.token },
        });
    }

    ngOnDestroy(): void {
        this.dialogRef.close();
    }
}
