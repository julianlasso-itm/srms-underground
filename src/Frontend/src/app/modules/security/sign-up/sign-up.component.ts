import {
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  Renderer2,
  ViewChild,
} from '@angular/core';
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
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { Constant } from '../../shared/constants/constants';
import { HttpService } from '../../shared/services/http.service';
import { SharedModule } from '../../shared/shared.module';
import { HttpHeaders } from '@angular/common/http';

const URL_SIGN_UP = `${Constant.URL_BASE}${Constant.URL_SIGN_UP}`;

@Component({
  selector: 'srms-sign-up',
  standalone: true,
  imports: [
    FormsModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatProgressBarModule,
    MatSnackBarModule,
    ReactiveFormsModule,
    SharedModule,
    ],
  providers: [HttpService],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss',
})
export class SignUpComponent implements OnInit, OnDestroy {
  @ViewChild('fileInput') fileInput!: ElementRef;
  @ViewChild('dragArea') dragArea!: ElementRef;
  @ViewChild('avatar', { static: false }) avatar!: ElementRef;

  frmSignUp: FormGroup;

  private frmSignUpSubscription: Subscription;

  constructor(
    private renderer: Renderer2,
    private _snackBar: MatSnackBar,
    private readonly httpService: HttpService
  ) {
    this.frmSignUp = new FormGroup(
      {
        name: new FormControl('', [Validators.required]),
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [Validators.required]),
        passwordConfirmation: new FormControl('', [Validators.required]),
        avatar: new FormControl(null, [Validators.required]),
      },
      { validators: SignUpComponent.passwordsMatch }
    );

    this.frmSignUpSubscription = this.frmSignUp.valueChanges.subscribe(
      (value) => {
        if (this.frmSignUp.hasError('passwordsDontMatch')) {
          this.frmSignUp.get('passwordConfirmation')?.setErrors({
            passwordsDontMatch: true,
          });
        }

        if (
          this.frmSignUp.get('avatar')?.invalid &&
          this.frmSignUp.get('name')?.valid &&
          this.frmSignUp.get('email')?.valid &&
          this.frmSignUp.get('password')?.valid &&
          this.frmSignUp.get('passwordConfirmation')?.valid
        ) {
          this.frmSignUp.get('avatar')?.setErrors({ required: true });
          this._snackBar.open(
            'Por favor, selecciona una imagen válida de perfil.',
            'Cerrar'
          );
        }
      }
    );
  }

  ngOnInit(): void {
    // Empty
  }

  ngOnDestroy(): void {
    this.frmSignUpSubscription.unsubscribe();
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

  onDragOver(event: DragEvent) {
    event.preventDefault();
    event.stopPropagation();
    this.renderer.addClass(this.dragArea.nativeElement, 'dragging');
  }

  onDragLeave(event: DragEvent) {
    event.preventDefault();
    event.stopPropagation();
    this.renderer.removeClass(this.dragArea.nativeElement, 'dragging');
  }

  onDrop(event: DragEvent) {
    event.preventDefault();
    event.stopPropagation();
    if (event.dataTransfer) {
      const files = event.dataTransfer.files;
      if (files.length > 0) {
        this.fileInput.nativeElement.files = files;
        this.fileInput.nativeElement.dispatchEvent(new Event('change'));
      }
      this.renderer.removeClass(this.dragArea.nativeElement, 'dragging');
    }
  }

  triggerFileInput() {
    this.fileInput.nativeElement.click();
  }

  onFileSelect(event: Event) {
    const fileInput = event.target as HTMLInputElement;
    if (fileInput.files && fileInput.files.length > 0) {
      const file = fileInput.files[0];

      const maxFileSize = 500 * 1024; // 500 KB

      if (file.size > maxFileSize) {
        console.error('El archivo es demasiado grande.');
        this._snackBar.open(
          'El archivo no debe exceder los 500 KB.',
          'Cerrar',
          {
            duration: 5000,
          }
        );
        return; // Detiene la función si el archivo es demasiado grande
      }

      if (file.type.startsWith('image/')) {
        const img = new Image();
        const url = URL.createObjectURL(file);
        img.onload = () => {
          URL.revokeObjectURL(url); // Limpia el URL creado para liberar memoria
          if (img.width === img.height) {
            // Procesar la imagen si es cuadrada
            const reader = new FileReader();
            reader.onload = (progressEvent: ProgressEvent<FileReader>) => {
              this.renderer.setProperty(
                this.avatar.nativeElement,
                'src',
                progressEvent.target?.result
              );
            };
            reader.readAsDataURL(file);
            this.frmSignUp.get('avatar')?.setValue(file);
          } else {
            // Manejar el caso en que la imagen no sea cuadrada
            console.error('La imagen debe ser cuadrada.');
            this._snackBar.open(
              'Por favor, sube una imagen con dimensiones cuadradas.',
              'Cerrar',
              {
                duration: 5000,
              }
            );
          }
        };
        img.onerror = () => {
          console.error('Error al cargar la imagen.');
          this._snackBar.open(
            'Ocurrió un error al cargar la imagen.',
            'Cerrar',
            {
              duration: 5000,
            }
          );
        };
        img.src = url;
      } else {
        console.error('El archivo seleccionado no es una imagen.');
        this._snackBar.open(
          'Por favor, selecciona un archivo de imagen válido.',
          'Cerrar',
          {
            duration: 5000,
          }
        );
      }
    }
  }

  onSubmit() {
    const data = this.frmSignUp.value;
    console.log(data);

    const formData = new FormData();
    formData.append('name', data.name);
    formData.append('email', data.email);
    formData.append('password', data.password);
    formData.append('avatar', data.avatar, data.avatar.name);

    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    this.httpService.post<FormData, any>(URL_SIGN_UP, formData, undefined, headers).subscribe({
      next: (response) => {
        console.log(response);
        this._snackBar.open('Usuario creado exitosamente.', 'Cerrar', {
          duration: 5000,
        });
      },
      complete: () => {
        console.log('Sign up complete');
      },
      error: (error) => {
        console.error(error);
        this._snackBar.open('Ocurrió un error al crear el usuario.', 'Cerrar', {
          duration: 5000,
        });
      },
    });
  }
}