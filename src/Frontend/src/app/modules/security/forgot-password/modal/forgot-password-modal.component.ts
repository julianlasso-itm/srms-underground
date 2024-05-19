import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
    FormControl,
    FormGroup,
    FormsModule,
    ReactiveFormsModule,
    Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Router, RouterModule } from '@angular/router';
import { Constant } from '../../../shared/constants/constants';
import { HttpService } from '../../../shared/services/http.service';
import { SharedModule } from '../../../shared/shared.module';

const URL_PASSWORD_RECOVERY = `${Constant.URL_BASE}${Constant.URL_PASSWORD_RECOVERY}`;

@Component({
    selector: 'srms-forgot-password-modal',
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        MatButtonModule,
        MatDialogModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatProgressSpinnerModule,
        MatSnackBarModule,
        ReactiveFormsModule,
        SharedModule,
        RouterModule,
    ],
    providers: [HttpService],
    templateUrl: './forgot-password-modal.component.html',
    styleUrl: './forgot-password-modal.component.scss',
})
export class ForgotPasswordModalComponent {
    frmForgotPassword: FormGroup;

    constructor(
        private readonly httpService: HttpService,
        private readonly snackBar: MatSnackBar,
        private readonly router: Router
    ) {
        this.frmForgotPassword = this.defineForm();
    }

    onSubmit(): void {
        this.httpService
            .post(URL_PASSWORD_RECOVERY, this.frmForgotPassword.value)
            .subscribe({
                next: () => {
                    this.snackBar.open(
                        'Un email de recuperación de contraseña ha sido enviado a su correo electrónico.',
                        'Cerrar',
                        {
                            duration: 5000,
                        }
                    );
                    this.router.navigate(['./security/sign-in']);
                },
                error: (error) => {
                    console.error(
                        'Error sending password recovery email',
                        error
                    );
                },
            });
    }

    private defineForm(): FormGroup {
        return new FormGroup({
            email: new FormControl('', [Validators.required, Validators.email]),
        });
    }
}
