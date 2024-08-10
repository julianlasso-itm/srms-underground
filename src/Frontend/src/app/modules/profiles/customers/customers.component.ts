import { Component } from '@angular/core';

import { MatDialogModule } from '@angular/material/dialog';

import { TableComponent } from '../../../components/table';

@Component({
  selector: 'srms-customers',
  standalone: true,
  imports: [TableComponent, MatDialogModule],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.scss',
})
export class CustomersComponent {
  displayedColumns = signal([
    { name: 'Nombre', field: 'name' },
    { name: 'Correo Electrónico', field: 'email' },
    { name: 'Teléfono', field: 'phone' },
    { name: 'Ciudad', field: 'city' },
    { name: 'País', field: 'country' },
    { name: 'Estado', field: 'status' },
    { name: 'Acciones', field: 'actions' },
  ]);
  dataSource = signal(customers);
  constructor(private dialog: MatDialog) {
    customers.forEach((customer) => {
      customer.actions = [
        {
          icon: 'edit',
          tooltip: 'Editar',
          action: this.editCustomer.bind(this, customer),
        },
        {
          icon: 'delete',
          tooltip: 'Eliminar',
          action: this.deleteCustomer.bind(this, customer),
        },
      ];
    });
    this.dataSource.set(customers);
  }
  editCustomer(customer: ICustomer) {
    // console.log('Edit', customer);
    this.dialog.open(ModalForFormComponent, {
      disableClose: true,
      autoFocus: false,
      width: '450px',
      data: {
        title: 'Editar Cliente',
        submit: this.editCustomerSubmit,
        action: 'Editar',
        form: this.getFieldsInfo(),
        data: customer,
      },
    });
  }
  private editCustomerSubmit(): void {
    // console.log('Submit edit', this.form().getRawValue());
    console.log('Submit edit');
  }
  deleteCustomer(customer: ICustomer) {
    console.log('Delete', customer);
  }
  pageEvent(event: PageEvent) {
    console.log(event);
  }
  private getFieldsInfo(): WritableSignal<Array<FormField>> {
    return signal([
      {
        field: 'id',
        type: TypeInput.HIDDEN,
        formControl: signal(
          new FormControl(null, {
            nonNullable: true,
            validators: [Validators.required],
          })
        ),
      },
      {
        field: 'name',
        label: 'Nombre',
        type: TypeInput.TEXT,
        placeholder: 'Nombre del cliente',
        maxLength: 100,
        icon: 'person',
        formControl: signal(
          new FormControl(null, {
            nonNullable: true,
            validators: [Validators.required, Validators.maxLength(100)],
          })
        ),
      },
      {
        field: 'email',
        label: 'Correo Electrónico',
        type: TypeInput.EMAIL,
        placeholder: 'Correo Electrónico',
        maxLength: 500,
        icon: 'email',
        formControl: signal(
          new FormControl(null, {
            nonNullable: true,
            validators: [
              Validators.required,
              Validators.email,
              Validators.maxLength(500),
            ],
          })
        ),
      },
      {
        field: 'phone',
        label: 'Teléfono',
        type: TypeInput.TEL,
        placeholder: 'Teléfono',
        maxLength: 20,
        icon: 'phone',
        formControl: signal(
          new FormControl(null, {
            nonNullable: true,
            validators: [Validators.required, Validators.maxLength(20)],
          })
        ),
      },
      {
        field: 'address',
        label: 'Dirección',
        type: TypeInput.TEXT,
        placeholder: 'Dirección',
        maxLength: 500,
        icon: 'home',
        formControl: signal(
          new FormControl(null, {
            nonNullable: true,
            validators: [Validators.required, Validators.maxLength(500)],
          })
        ),
      },
      {
        field: 'country',
        label: 'País',
        type: TypeInput.SELECT,
        placeholder: 'País',
        maxLength: 32,
        icon: 'location_city',
        formControl: signal(
          new FormControl(null, {
            nonNullable: true,
            validators: [Validators.required, Validators.maxLength(32)],
          })
        ),
        loadOptions: this.loadCountries.bind(this),
        selectionChange: this.loadStates.bind(this),
      },
      {
        field: 'state',
        label: 'Estado',
        type: TypeInput.SELECT,
        placeholder: 'Estado',
        maxLength: 32,
        icon: 'location_city',
        selectionChange: this.loadCities.bind(this),
        formControl: signal(
          new FormControl(
            {
              value: null,
              disabled: true,
            },
            {
              nonNullable: true,
              validators: [Validators.required, Validators.maxLength(32)],
            }
          )
        ),
      },
      {
        field: 'city',
        label: 'Ciudad',
        type: TypeInput.SELECT,
        placeholder: 'Ciudad',
        maxLength: 36,
        icon: 'location_city',
        formControl: signal(
          new FormControl(
            {
              value: null,
              disabled: true,
            },
            {
              nonNullable: true,
              validators: [Validators.required, Validators.maxLength(36)],
            }
          )
        ),
        loadOptions: this.loadCities.bind(this),
      },
      {
        field: 'status',
        label: 'Estado',
        type: TypeInput.SLIDE_TOGGLE,
        defaultValue: true,
        formControl: signal(
          new FormControl(null, {
            nonNullable: true,
            validators: [Validators.required],
          })
        ),
      },
    ]);
  }
  private loadCountries(): Array<object> {
    return [
      { value: 'Mexico', label: 'México' },
      { value: 'USA', label: 'Estados Unidos' },
      { value: 'Canada', label: 'Canadá' },
    ];
  }
  private loadStates(country: string): Array<object> {
    switch (country) {
      case 'Mexico':
        return [
          { value: 'Aguascalientes', label: 'Aguascalientes' },
          { value: 'Baja California', label: 'Baja California' },
          { value: 'Baja California Sur', label: 'Baja California Sur' },
          { value: 'Campeche', label: 'Campeche' },
          { value: 'Chiapas', label: 'Chiapas' },
          { value: 'Chihuahua', label: 'Chihuahua' },
          { value: 'Coahuila', label: 'Coahuila' },
          { value: 'Colima', label: 'Colima' },
          { value: 'Durango', label: 'Durango' },
          { value: 'Guanajuato', label: 'Guanajuato' },
          { value: 'Guerrero', label: 'Guerrero' },
          { value: 'Hidalgo', label: 'Hidalgo' },
          { value: 'Jalisco', label: 'Jalisco' },
          { value: 'México', label: 'México' },
          { value: 'Michoacán', label: 'Michoacán' },
          { value: 'Morelos', label: 'Morelos' },
          { value: 'Nayarit', label: 'Nayarit' },
          { value: 'Nuevo León', label: 'Nuevo León' },
          { value: 'Oaxaca', label: 'Oaxaca' },
          { value: 'Puebla', label: 'Puebla' },
          { value: 'Querétaro', label: 'Querétaro' },
          { value: 'Quintana Roo', label: 'Quintana Roo' },
          { value: 'San Luis Potosí', label: 'San Luis Potosí' },
          { value: 'Sinaloa', label: 'Sinaloa' },
          { value: 'Sonora', label: 'Sonora' },
          { value: 'Tabasco', label: 'Tabasco' },
          { value: 'Tamaulipas', label: 'Tamaulipas' },
          { value: 'Tlaxcala', label: 'Tlaxcala' },
          { value: 'Veracruz', label: 'Veracruz' },
          { value: 'Yucatán', label: 'Yucatán' },
          { value: 'Zacatecas', label: 'Zacatecas' },
          { value: 'CDMX', label: 'Ciudad de México' },
        ];
      case 'USA':
        return [
          { value: 'Alabama', label: 'Alabama' },
          { value: 'Alaska', label: 'Alaska' },
          { value: 'Arizona', label: 'Arizona' },
          { value: 'Arkansas', label: 'Arkansas' },
          { value: 'California', label: 'California' },
          { value: 'Colorado', label: 'Colorado' },
          { value: 'Connecticut', label: 'Connecticut' },
          { value: 'Delaware', label: 'Delaware' },
          { value: 'Florida', label: 'Florida' },
          { value: 'Georgia', label: 'Georgia' },
          { value: 'Hawaii', label: 'Hawaii' },
          { value: 'Idaho', label: 'Idaho' },
          { value: 'Illinois', label: 'Illinois' },
          { value: 'Indiana', label: 'Indiana' },
          { value: 'Iowa', label: 'Iowa' },
          { value: 'Kansas', label: 'Kansas' },
          { value: 'Kentucky', label: 'Kentucky' },
          { value: 'Louisiana', label: 'Louisiana' },
          { value: 'Maine', label: 'Maine' },
          { value: 'Maryland', label: 'Maryland' },
          { value: 'Massachusetts', label: 'Massachusetts' },
          { value: 'Michigan', label: 'Michigan' },
          { value: 'Minnesota', label: 'Minnesota' },
          { value: 'Mississippi', label: 'Mississippi' },
          { value: 'Missouri', label: 'Missouri' },
          { value: 'Montana', label: 'Montana' },
          { value: 'Nebraska', label: 'Nebraska' },
          { value: 'Nevada', label: 'Nevada' },
          { value: 'New Hampshire', label: 'New Hampshire' },
          { value: 'New Jersey', label: 'New Jersey' },
          { value: 'New Mexico', label: 'New Mexico' },
          { value: 'New York', label: 'New York' },
          { value: 'North Carolina', label: 'North Carolina' },
          { value: 'North Dakota', label: 'North Dakota' },
          { value: 'Ohio', label: 'Ohio' },
          { value: 'Oklahoma', label: 'Oklahoma' },
          { value: 'Oregon', label: 'Oregon' },
          { value: 'Pennsylvania', label: 'Pennsylvania' },
          { value: 'Rhode Island', label: 'Rhode Island' },
          { value: 'South Carolina', label: 'South Carolina' },
          { value: 'South Dakota', label: 'South Dakota' },
          { value: 'Tennessee', label: 'Tennessee' },
          { value: 'Texas', label: 'Texas' },
          { value: 'Utah', label: 'Utah' },
          { value: 'Vermont', label: 'Vermont' },
          { value: 'Virginia', label: 'Virginia' },
          { value: 'Washington', label: 'Washington' },
          { value: 'West Virginia', label: 'West Virginia' },
          { value: 'Wisconsin', label: 'Wisconsin' },
          { value: 'Wyoming', label: 'Wyoming' },
        ];
      case 'Canada':
        return [
          { value: 'Alberta', label: 'Alberta' },
          { value: 'British Columbia', label: 'British Columbia' },
          { value: 'Manitoba', label: 'Manitoba' },
          { value: 'New Brunswick', label: 'New Brunswick' },
          {
            value: 'Newfoundland and Labrador',
            label: 'Newfoundland and Labrador',
          },
          { value: 'Nova Scotia', label: 'Nova Scotia' },
          { value: 'Ontario', label: 'Ontario' },
          { value: 'Prince Edward Island', label: 'Prince Edward Island' },
          { value: 'Quebec', label: 'Quebec' },
          { value: 'Saskatchewan', label: 'Saskatchewan' },
          { value: 'Northwest Territories', label: 'Northwest Territories' },
          { value: 'Nunavut', label: 'Nunavut' },
          { value: 'Yukon', label: 'Yukon' },
        ];
      default:
        return [];
    }
  }
  private loadCities(state: string): Array<object> {
    switch (state) {
      case 'CDMX':
        return [
          { value: 'Álvaro Obregón', label: 'Álvaro Obregón' },
          { value: 'Azcapotzalco', label: 'Azcapotzalco' },
          { value: 'Benito Juárez', label: 'Benito Juárez' },
          { value: 'Coyoacán', label: 'Coyoacán' },
          { value: 'Cuajimalpa', label: 'Cuajimalpa' },
          { value: 'Cuauhtémoc', label: 'Cuauhtémoc' },
          { value: 'Gustavo A. Madero', label: 'Gustavo A. Madero' },
          { value: 'Iztacalco', label: 'Iztacalco' },
          { value: 'Iztapalapa', label: 'Iztapalapa' },
          { value: 'Magdalena Contreras', label: 'Magdalena Contreras' },
          { value: 'Miguel Hidalgo', label: 'Miguel Hidalgo' },
          { value: 'Milpa Alta', label: 'Milpa Alta' },
          { value: 'Tláhuac', label: 'Tláhuac' },
          { value: 'Tlalpan', label: 'Tlalpan' },
          { value: 'Venustiano Carranza', label: 'Venustiano Carranza' },
          { value: 'Xochimilco', label: 'Xochimilco' },
        ];
      default:
        return [];
    }
  }
}
