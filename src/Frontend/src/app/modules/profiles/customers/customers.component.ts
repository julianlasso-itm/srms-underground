import { Component, signal } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { TableComponent } from '../../../components/table/table.component';
import { customers, ICustomer } from './customer.interface';

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
    { name: 'Acciones', field: 'actions' },
  ]);
  dataSource = signal(customers);

  constructor() {
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
    console.log('Edit', customer);
  }

  deleteCustomer(customer: ICustomer) {
    console.log('Delete', customer);
  }

  pageEvent(event: PageEvent) {
    console.log(event);
  }
}
