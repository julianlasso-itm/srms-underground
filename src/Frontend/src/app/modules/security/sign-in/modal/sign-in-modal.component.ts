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
import { AuthService } from '../../../shared/services/auth.service';
import { HttpService } from '../../../shared/services/http.service';
import { StoreService } from '../../../shared/services/store.service';
import { SharedModule } from '../../../shared/shared.module';
import { TokenDto } from './token.dto';

const URL_ROLE = `${Constant.URL_BASE}${Constant.URL_SIGN_IN}`;

@Component({
    selector: 'srms-sign-in-modal',
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
    providers: [HttpService, StoreService],
    templateUrl: './sign-in-modal.component.html',
    styleUrl: './sign-in-modal.component.scss',
})
export class SignInModalComponent {
    frmSignIn: FormGroup;

    constructor(
        private readonly httpService: HttpService,
        private readonly _snackBar: MatSnackBar,
        private readonly _storeService: StoreService,
        private readonly _authService: AuthService,
        private readonly _router: Router
    ) {
        this.frmSignIn = this.defineForm();
    }

    onSubmit(): void {
        this.httpService
            .post<any, TokenDto>(URL_ROLE, this.frmSignIn.value)
            .subscribe({
                next: (response) => {
                    this._storeService.setToken(response.token);
                    this._authService.ChangeIsAuth();
                    this._router.navigate(['./home']);
                },
                error: (error) => {
                    if (error.status === 401) {
                        this._snackBar.open(
                            'Datos de acceso incorrectos',
                            'Cerrar',
                            {
                                duration: 5000,
                            }
                        );
                        return;
                    }

                    if (error.status === 403) {
                        this._snackBar.open(
                            'El usuario fue bloqueado por 5 minutos',
                            'Cerrar',
                            {
                                duration: 5000,
                            }
                        );
                        return;
                    }

                    this._snackBar.open(error.message, 'Close', {
                        duration: 5000,
                    });
                },
            });
    }

    private defineForm(): FormGroup {
        return new FormGroup({
            email: new FormControl('', [Validators.required, Validators.email]),
            password: new FormControl('', [Validators.required]),
        });
    }
}
