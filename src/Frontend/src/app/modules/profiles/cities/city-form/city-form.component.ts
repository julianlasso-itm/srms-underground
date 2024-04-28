import { CommonModule } from '@angular/common';
import { HttpParams } from '@angular/common/http';
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
import { MatSelectChange, MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Constant } from '../../../shared/constants/constants';
import { HttpService } from '../../../shared/services/http.service';
import { ReloadDataService } from '../../../shared/services/reload-data.service';
import { SharedModule } from '../../../shared/shared.module';
import { ICountry } from '../../countries/country/country.interface';
import { IProvince } from '../../provinces/province/province.interface';
import { ICity } from '../city/city.interface';

const URL_CITY = `${Constant.URL_BASE}${Constant.URL_CITY}`;
const URL_GET_PROVINCES = `${Constant.URL_BASE}${Constant.URL_GET_PROVINCES}`;
const URL_GET_COUNTRIES = `${Constant.URL_BASE}${Constant.URL_GET_COUNTRIES}`;

@Component({
  selector: 'srms-city-form',
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
  templateUrl: './city-form.component.html',
  styleUrl: './city-form.component.scss',
})
export class CityFormComponent implements OnInit {
  @Input() city: Signal<ICity | null> = signal(null);
  @Output('frmCity') form: EventEmitter<Signal<FormGroup>>;
  public frmCity: Signal<FormGroup>;
  private regexp =
    '^[0-9A-Za-z]{8}-[0-9A-Za-z]{4}-4[0-9A-Za-z]{3}-[89ABab][0-9A-Za-z]{3}-[0-9A-Za-z]{12}$';
  provinces: IProvince[];
  countries: ICountry[];

  constructor(
    private snackBar: MatSnackBar,
    public httpService: HttpService,
    public reloadDataService: ReloadDataService
  ) {
    this.provinces = [];
    this.countries = [];
    this.frmCity = signal(
      new FormGroup({
        name: new FormControl('', [
          Validators.required,
          Validators.maxLength(50),
        ]),
        countryId: new FormControl('', [Validators.required]),
        provinceId: new FormControl('', [Validators.required]),
      })
    );
    this.form = new EventEmitter<Signal<FormGroup>>();
  }

  ngOnInit(): void {
    if (this.city()?.cityId !== undefined) {
      this.frmCity().setControl(
        'cityId',
        new FormControl(this.city()?.cityId, [
          Validators.required,
          Validators.pattern(this.regexp),
        ])
      );
      this.frmCity().get('name')?.setValue(this.city()?.name);
      this.frmCity()
        .get('countryId')
        ?.setValue(this.city()?.province.countryId);
      this.frmCity().get('provinceId')?.setValue(this.city()?.provinceId);
      this.frmCity().setControl(
        'disabled',
        new FormControl<boolean>(!this.city()?.disabled || false)
      );
      this.loadProvinces(this.city()?.province.countryId.countryId ?? '');
    }
    this.loadCountries();
    this.form.emit(computed(() => this.frmCity()));
  }

  onSubmit(): void {
    if (this.frmCity().valid) {
      if (this.city()?.cityId === undefined) {
        this.createCity();
      } else {
        this.updateCity();
      }
    }
  }

  onCountryChange(event: MatSelectChange): void {
    if (event.value === undefined || event.value === '') {
      this.provinces = [];
    } else {
      this.loadProvinces(event.value);
    }
    this.frmCity().get('provinceId')?.setValue('');
  }

  private createCity(): void {
    const body = this.frmCity().value;
    this.httpService.post(URL_CITY, body).subscribe({
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

  private updateCity(): void {
    const body = this.frmCity().value;
    body.disable = !body.disabled;
    delete body.disabled;

    const url = `${URL_CITY}/${this.city()?.cityId}`;
    delete body.cityId;
    delete body.countryId;

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
    this.frmCity().disable();
    let params = new HttpParams().append('Page', 1).append('Limit', 9999999);
    this.httpService.get(URL_GET_COUNTRIES, params).subscribe({
      next: (response: any) => {
        console.log(response);
        this.countries = response.countries;
        this.frmCity().enable();
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

  private loadProvinces(countryId: string): void {
    this.frmCity().disable();
    let params: HttpParams;
    if (countryId === '') {
      params = new HttpParams().append('Page', 1).append('Limit', 9999999);
    } else {
      params = new HttpParams()
        .append('Page', 1)
        .append('Limit', 9999999)
        .append('Filter', countryId)
        .append('FilterBy', 'CountryId');
    }
    this.httpService.get(URL_GET_PROVINCES, params).subscribe({
      next: (response: any) => {
        console.log(response);
        this.provinces = response.provinces;
        this.frmCity().enable();
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
