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
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RouterModule } from '@angular/router';
import { HttpService } from '../../../shared/services/http.service';
import { SharedModule } from '../../../shared/shared.module';
import { Subscription } from 'rxjs';

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

  constructor(private readonly httpService: HttpService) {
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
    console.log(this.frmResetPassword.value);
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
        password: new FormControl('', [Validators.required]),
        passwordConfirmation: new FormControl('', [Validators.required]),
      },
      { validators: ResetPasswordModalComponent.passwordsMatch }
    );
  }
}
