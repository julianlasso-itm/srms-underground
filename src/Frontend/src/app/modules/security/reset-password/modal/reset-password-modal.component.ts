import { CommonModule } from '@angular/common';
import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  ValidationErrors,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Router, RouterModule } from '@angular/router';
import { Subscription } from 'rxjs';
import { Constant } from '../../../shared/constants/constants';
import { HttpService } from '../../../shared/services/http.service';
import { SharedModule } from '../../../shared/shared.module';

const URL_RESET_PASSWORD = `${Constant.URL_BASE}${Constant.URL_RESET_PASSWORD}`;

@Component({
  selector: 'srms-reset-password-modal',
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
    RouterModule,
    SharedModule,
  ],
  providers: [HttpService],
  templateUrl: './reset-password-modal.component.html',
  styleUrl: './reset-password-modal.component.scss',
})
export class ResetPasswordModalComponent implements OnInit, OnDestroy {
  frmResetPassword: FormGroup;
  private frmResetPasswordSubscription!: Subscription;

  constructor(
    private readonly httpService: HttpService,
    private readonly openSnackBar: MatSnackBar,
    private readonly router: Router,
    @Inject(MAT_DIALOG_DATA) public data: { token: string }
  ) {
    this.frmResetPassword = this.defineForm();
  }

  ngOnInit(): void {
    this.frmResetPasswordSubscription =
      this.frmResetPassword.valueChanges.subscribe((value) => {
        if (this.frmResetPassword.hasError('passwordsDontMatch')) {
          this.frmResetPassword.get('passwordConfirmation')?.setErrors({
            passwordsDontMatch: true,
          });
        }
      });
  }

  ngOnDestroy(): void {
    this.frmResetPasswordSubscription.unsubscribe();
  }

  onSubmit(): void {
    const body = this.frmResetPassword.value;
    delete body.passwordConfirmation;
    this.httpService
      .post(URL_RESET_PASSWORD, this.frmResetPassword.value)
      .subscribe({
        next: () => {
          this.openSnackBar.open('Contraseña cambiada con éxito.', 'Cerrar', {
            duration: 5000,
          });
          this.router.navigate(['./security/sign-in']);
        },
        error: (error) => {
          this.openSnackBar.open(
            'Ocurrió un error al intentar cambiar la contraseña. Por favor, intente nuevamente.',
            'Cerrar',
            {
              duration: 5000,
            }
          );
        },
      });
  }

  static readonly passwordsMatch: ValidatorFn = (
    control: AbstractControl
  ): ValidationErrors | null => {
    const group = control as FormGroup;
    const password = group.get('password')?.value;
    const passwordConfirmation = group.get('passwordConfirmation')?.value;
    return password === passwordConfirmation
      ? null
      : { passwordsDontMatch: true };
  };

  private defineForm(): FormGroup {
    return new FormGroup(
      {
        token: new FormControl(this.data.token, [Validators.required]),
        password: new FormControl('', [Validators.required]),
        passwordConfirmation: new FormControl('', [Validators.required]),
      },
      { validators: ResetPasswordModalComponent.passwordsMatch }
    );
  }
}
