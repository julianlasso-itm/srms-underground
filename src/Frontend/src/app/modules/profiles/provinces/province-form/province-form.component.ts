import { CommonModule } from '@angular/common';
import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  Signal,
  computed,
  signal,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Constant } from '../../../shared/constants/constants';
import { HttpService } from '../../../shared/services/http.service';
import { ReloadDataService } from '../../../shared/services/reload-data.service';
import { SharedModule } from '../../../shared/shared.module';
import { IProvince } from '../province/province.interface';
import { HttpParams } from '@angular/common/http';
import { ICountry } from '../../countries/country/country.interface';

const URL_PROVINCE = `${Constant.URL_BASE}${Constant.URL_PROVINCE}`;
const URL_GET_COUNTRIES = `${Constant.URL_BASE}${Constant.URL_GET_COUNTRIES}`;

@Component({
  selector: 'srms-province-form',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    ReactiveFormsModule,
    SharedModule,
  ],
  templateUrl: './province-form.component.html',
  styleUrl: './province-form.component.scss',
})
export class ProvinceFormComponent implements OnInit {
  @Input() province: Signal<IProvince | null> = signal(null);
  @Output('frmProvince') form: EventEmitter<Signal<FormGroup>>;
  public frmProvince: Signal<FormGroup>;
  private regexp =
    '^[0-9A-Za-z]{8}-[0-9A-Za-z]{4}-4[0-9A-Za-z]{3}-[89ABab][0-9A-Za-z]{3}-[0-9A-Za-z]{12}$';
  countries: ICountry[];

  constructor(
    private snackBar: MatSnackBar,
    public httpService: HttpService,
    public reloadDataService: ReloadDataService
  ) {
    this.countries = [];
    this.frmProvince = signal(
      new FormGroup({
        name: new FormControl('', [
          Validators.required,
          Validators.maxLength(50),
        ]),
        countryId: new FormControl('', [Validators.required]),
      })
    );
    this.form = new EventEmitter<Signal<FormGroup>>();
  }

  ngOnInit(): void {
    if (this.province()?.provinceId !== undefined) {
      this.frmProvince().setControl(
        'provinceId',
        new FormControl(this.province()?.provinceId, [
          Validators.required,
          Validators.pattern(this.regexp),
        ])
      );
      this.frmProvince().get('name')?.setValue(this.province()?.name);
      this.frmProvince().get('countryId')?.setValue(this.province()?.countryId);
      this.frmProvince().setControl(
        'disabled',
        new FormControl<boolean>(!this.province()?.disabled || false)
      );
    }
    this.form.emit(computed(() => this.frmProvince()));
    this.loadCountries();
  }

  onSubmit(): void {
    if (this.frmProvince().valid) {
      if (this.province()?.provinceId === undefined) {
        this.createProvince();
      } else {
        this.updateProvince();
      }
    }
  }

  private createProvince(): void {
    const body = this.frmProvince().value;
    this.httpService.post(URL_PROVINCE, body).subscribe({
      next: (response) => {
        console.log(response);
        this.reloadDataService.reload();
      },
      error: (error) => {
        console.error(error);
        this.handleException(error);
      },
      complete: () => {
        console.log('complete');
      },
    });
  }

  private updateProvince(): void {
    const body = this.frmProvince().value;
    body.disable = !body.disabled;
    delete body.disabled;

    const url = `${URL_PROVINCE}/${this.province()?.provinceId}`;
    delete body.provinceId;

    this.httpService.put(url, body).subscribe({
      next: (response) => {
        console.log(response);
        this.reloadDataService.reload();
      },
      error: (error) => {
        console.error(error);
        this.handleException(error);
      },
      complete: () => {
        console.log('complete');
      },
    });
  }

  private loadCountries(): void {
    this.frmProvince().disable();
    let params = new HttpParams().append('Page', 1).append('Limit', 9999999);
    this.httpService.get(URL_GET_COUNTRIES, params).subscribe({
      next: (response: any) => {
        console.log(response);
        this.countries = response.countries;
        this.frmProvince().enable();
      },
      error: (error) => {
        console.error(error);
        this.handleException(error);
      },
      complete: () => {
        console.log('complete');
      },
    });
  }

  private handleException(error: any): void {
    const errorMessages = new Map([
      ['409_23505', 'El registro ya existe'],
      [
        '409_23503',
        'No es posible eliminar un registro porque tiene otros registros asociados',
      ],
    ]);

    const errorKey = `${error.status}_${error.error.Errors.substring(0, 5)}`;
    const message =
      errorMessages.get(errorKey) ?? error.error.Errors ?? 'Error desconocido';

    this.snackBar.open(message, 'Cerrar', { duration: 5000 });
  }
}
