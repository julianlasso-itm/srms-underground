import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
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
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatFormField, MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { Constant } from '../../shared/constants/constants';
import { AuthService } from '../../shared/services/auth.service';
import { HttpService } from '../../shared/services/http.service';
import { ProfileModel } from './profile.dto';

const URL_CHANGE_PASSWORD = `${Constant.URL_BASE}${Constant.URL_CHANGE_PASSWORD}`;

@Component({
  selector: 'srms-profile',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatDividerModule,
    MatFormField,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatSnackBarModule,
    ReactiveFormsModule,
  ],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent implements OnInit, OnDestroy {
  profile!: ProfileModel;
  private token: string = '';
  frmPassword: FormGroup;
  private frmResetPasswordSubscription!: Subscription;

  constructor(
    private authService: AuthService,
    private httpService: HttpService,
    private openSnackBar: MatSnackBar
  ) {
    this.frmPassword = this.defineFormUpdatePassword();
  }

  ngOnInit() {
    this.profile = this.authService.getTokenData();
    this.frmResetPasswordSubscription = this.frmPassword.valueChanges.subscribe(
      (value) => {
        if (this.frmPassword.hasError('passwordsDontMatch')) {
          this.frmPassword.get('confirmPassword')?.setErrors({
            passwordsDontMatch: true,
          });
        }
      }
    );
  }

  ngOnDestroy(): void {
    this.frmResetPasswordSubscription.unsubscribe();
  }

  defineFormUpdatePassword(): FormGroup {
    return new FormGroup(
      {
        password: new FormControl('', [Validators.required]),
        newPassword: new FormControl('', [Validators.required]),
        confirmPassword: new FormControl('', [Validators.required]),
      },
      { validators: ProfileComponent.passwordsMatch }
    );
  }

  static readonly passwordsMatch: ValidatorFn = (
    control: AbstractControl
  ): ValidationErrors | null => {
    const group = control as FormGroup;
    const password = group.get('newPassword')?.value;
    const passwordConfirmation = group.get('confirmPassword')?.value;
    return password === passwordConfirmation
      ? null
      : { passwordsDontMatch: true };
  };

  onSubmitChangePassword() {
    const body = {
      oldPassword: this.frmPassword.get('password')?.value,
      newPassword: this.frmPassword.get('newPassword')?.value,
    };

    this.httpService.post(URL_CHANGE_PASSWORD, body).subscribe({
      next: () => {
        this.openSnackBar.open('Contraseña cambiada con éxito.', 'Cerrar', {
          duration: 5000,
        });
        document.getElementById('btnResetPassword')?.click();
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
}
