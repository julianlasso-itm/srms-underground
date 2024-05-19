import { Component, OnDestroy } from '@angular/core';
import {
    MatDialog,
    MatDialogModule,
    MatDialogRef,
} from '@angular/material/dialog';
import { AuthService } from '../../../shared/services/auth.service';
import { SignInModalComponent } from '../modal/sign-in-modal.component';

@Component({
    selector: 'srms-sign-in',
    standalone: true,
    imports: [MatDialogModule],
    templateUrl: './sign-in.component.html',
    styleUrl: './sign-in.component.scss',
})
export class SignInComponent implements OnDestroy {
    private dialogRef: MatDialogRef<SignInModalComponent>;

    constructor(
        private dialog: MatDialog,
        private readonly authService: AuthService
    ) {
        this.dialogRef = this.dialog.open(SignInModalComponent, {
            width: '450px',
            disableClose: true,
        });
    }
    ngOnDestroy(): void {
        this.dialogRef.close();
    }
}
