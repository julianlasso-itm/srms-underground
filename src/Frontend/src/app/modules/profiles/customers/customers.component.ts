import { Component, signal } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { TableComponent } from '../../../components/table/table.component';
import { customers } from './customer.interface';

@Component({
  selector: 'srms-customers',
  standalone: true,
  imports: [TableComponent],
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
  ]);
  dataSource = signal(customers);

  pageEvent(event: PageEvent) {
    console.log(event);
  }
}
