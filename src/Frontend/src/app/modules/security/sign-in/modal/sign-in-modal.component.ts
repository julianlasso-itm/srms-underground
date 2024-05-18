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
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RouterModule } from '@angular/router';
import { HttpService } from '../../../shared/services/http.service';
import { SharedModule } from '../../../shared/shared.module';

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
  providers: [HttpService],
  templateUrl: './sign-in-modal.component.html',
  styleUrl: './sign-in-modal.component.scss',
})
export class SignInModalComponent {
  frmSignIn: FormGroup;

  constructor(private readonly httpService: HttpService) {
    this.frmSignIn = this.defineForm();
  }

  onSubmit(): void {
    console.log(this.frmSignIn.value);
  }

  private defineForm(): FormGroup {
    return new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
    });
  }
}
