import { CommonModule } from '@angular/common';
import { HttpParams } from '@angular/common/http';
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
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatFormField, MatInputModule } from '@angular/material/input';
import { MatSelectChange, MatSelectModule } from '@angular/material/select';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs';
import { ICity } from '../../profiles/cities/city/city.interface';
import { ICountry } from '../../profiles/countries/country/country.interface';
import { IProvince } from '../../profiles/provinces/province/province.interface';
import { Constant } from '../../shared/constants/constants';
import { AuthService } from '../../shared/services/auth.service';
import { AvatarService } from '../../shared/services/avatar.service';
import { HttpService } from '../../shared/services/http.service';
import { ProfileModel } from './profile.dto';

const URL_CHANGE_PASSWORD = `${Constant.URL_BASE}${Constant.URL_CHANGE_PASSWORD}`;
const URL_GET_PROVINCES = `${Constant.URL_BASE}${Constant.URL_GET_PROVINCES}`;
const URL_GET_COUNTRIES = `${Constant.URL_BASE}${Constant.URL_GET_COUNTRIES}`;
const URL_GET_CITIES = `${Constant.URL_BASE}${Constant.URL_GET_CITIES}`;
const URL_UPDATE_USER = `${Constant.URL_BASE}${Constant.URL_UPDATE_USER}`;

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
  @ViewChild('fileInput') fileInput!: ElementRef;
  @ViewChild('avatar', { static: false }) avatar!: ElementRef;
  profile!: ProfileModel;
  private token: string = '';
  frmPassword: FormGroup;
  frmPersonalData: FormGroup;
  private frmResetPasswordSubscription!: Subscription;
  private frmPersonalDataSubscription!: Subscription;
  countries: ICountry[];
  provinces: IProvince[];
  cities: ICity[];
  bntSubmitPersonalDataDisabled: boolean = false;
  private fileAvatar!: File;

  constructor(
    private authService: AuthService,
    private httpService: HttpService,
    private openSnackBar: MatSnackBar,
    private renderer: Renderer2,
    private avatarService: AvatarService
  ) {
    this.countries = [];
    this.provinces = [];
    this.cities = [];
    this.frmPersonalData = this.defineFormPersonalData();
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

    this.loadCountries();
  }

  ngOnDestroy(): void {
    this.frmResetPasswordSubscription.unsubscribe();
  }

  defineFormPersonalData(): FormGroup {
    return new FormGroup({
      name: new FormControl(''),
      cityId: new FormControl(''),
    });
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

  onSubmitPersonalData() {
    this.bntSubmitPersonalDataDisabled = true;
    const body = new FormData();
    body.append('name', this.frmPersonalData.get('name')?.value);
    body.append('cityId', this.frmPersonalData.get('cityId')?.value);

    if (this.fileAvatar) {
      body.append('avatar', this.fileAvatar, this.fileAvatar.name);
    }

    this.httpService.put(URL_UPDATE_USER, body).subscribe({
      next: (response: any) => {
        this.openSnackBar.open(
          'Datos personales actualizados con éxito.',
          'Cerrar',
          {
            duration: 5000,
          }
        );
        this.avatarService.set(response.photo);
      },
      error: (error) => {
        this.openSnackBar.open(
          'Ocurrió un error al intentar actualizar los datos personales. Por favor, intente nuevamente.',
          'Cerrar',
          {
            duration: 5000,
          }
        );
        this.bntSubmitPersonalDataDisabled = false;
      },
      complete: () => {
        this.bntSubmitPersonalDataDisabled = false;
      },
    });
  }

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

  onCountryChange(event: MatSelectChange): void {
    if (event.value === undefined || event.value === '') {
      this.provinces = [];
    } else {
      this.loadProvinces(event.value);
      this.cities = [];
      this.frmPersonalData.get('cityId')?.setValue('');
    }
  }

  onProvinceChange(event: MatSelectChange): void {
    if (event.value === undefined || event.value === '') {
      this.cities = [];
    } else {
      this.loadCities(event.value);
      this.frmPersonalData.get('cityId')?.setValue('');
    }
  }

  private loadCountries(): void {
    const params = new HttpParams()
      .append('Page', 1)
      .append('Limit', 9999999)
      .append('Sort', 'Name');
    this.httpService.get(URL_GET_COUNTRIES, params).subscribe({
      next: (response: any) => {
        console.log(response);
        this.countries = response.countries;
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.log('complete');
      },
    });
  }

  private loadProvinces(countryId: string): void {
    const params = new HttpParams()
      .append('Page', 1)
      .append('Limit', 9999999)
      .append('Filter', countryId)
      .append('FilterBy', 'CountryId')
      .append('Sort', 'Name');
    this.httpService.get(URL_GET_PROVINCES, params).subscribe({
      next: (response: any) => {
        console.log(response);
        this.provinces = response.provinces;
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.log('complete');
      },
    });
  }

  private loadCities(provinceId: string): void {
    const params = new HttpParams()
      .append('Page', 1)
      .append('Limit', 9999999)
      .append('Filter', provinceId)
      .append('FilterBy', 'ProvinceId')
      .append('Sort', 'Name');
    this.httpService.get(URL_GET_CITIES, params).subscribe({
      next: (response: any) => {
        console.log(response);
        this.cities = response.cities;
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.log('complete');
      },
    });
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
        this.openSnackBar.open(
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
            // this.frmSignUp.get('avatar')?.setValue(file);
            this.fileAvatar = file;
          } else {
            // Manejar el caso en que la imagen no sea cuadrada
            console.error('La imagen debe ser cuadrada.');
            this.openSnackBar.open(
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
          this.openSnackBar.open(
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
        this.openSnackBar.open(
          'Por favor, selecciona un archivo de imagen válido.',
          'Cerrar',
          {
            duration: 5000,
          }
        );
      }
    }
  }
}
