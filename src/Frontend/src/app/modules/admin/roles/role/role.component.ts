import { Component, signal } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RoleDialogComponent } from '../role-dialog/role-dialog.component';
import { FormType } from '../role-dialog/dialog.type';
import { DeleteDialogComponent } from '../../../shared/components/delete-dialog/delete-dialog.component';

export interface PeriodicElement {
  name: string;
  position: number;
  description: number;
  id: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Hydrogen', description: 1.0079, id: 'H' },
  { position: 2, name: 'Helium', description: 4.0026, id: 'He' },
  { position: 3, name: 'Lithium', description: 6.941, id: 'Li' },
  { position: 4, name: 'Beryllium', description: 9.0122, id: 'Be' },
  { position: 5, name: 'Boron', description: 10.811, id: 'B' },
  { position: 6, name: 'Carbon', description: 12.0107, id: 'C' },
  { position: 7, name: 'Nitrogen', description: 14.0067, id: 'N' },
  { position: 8, name: 'Oxygen', description: 15.9994, id: 'O' },
  { position: 9, name: 'Fluorine', description: 18.9984, id: 'F' },
  { position: 10, name: 'Neon', description: 20.1797, id: 'Ne' },
];

@Component({
  selector: 'srms-role-component',
  standalone: true,
  imports: [
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatIconModule,
    MatTooltipModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: './role.component.html',
  styleUrl: './role.component.scss',
})
export class RoleComponent {
  displayedColumns: string[] = ['position', 'name', 'description', 'id'];
  dataSource = ELEMENT_DATA;

  constructor(public dialog: MatDialog) {}

  openDialogNew(): void {
    this.dialog.open(RoleDialogComponent, {
      data: signal({ formType: FormType.CREATE }),
      width: '450px',
    });
  }

  openDialogEdit(id: string): void {
    this.dialog.open(RoleDialogComponent, {
      data: signal({ formType: FormType.EDIT, id }),
      width: '450px',
    });
  }

  openDialogDelete(id: string): void {
    this.dialog.open(DeleteDialogComponent, {
      data: { url: 'roles', id },
      width: '400px',
      autoFocus: false,
    });
  }
}
