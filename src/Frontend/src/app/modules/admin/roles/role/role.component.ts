import { Component, signal, OnInit, Signal } from '@angular/core';
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
import { IRole, type IRoles } from './role.interface';
import { HttpService } from '../../../shared/services/http.service';
import { Constant } from '../../../shared/constants/constants';
import { HttpClientModule } from '@angular/common/http';
import type { IPagination } from '../../../shared/interfaces/pagination.interface';

const URL = `${Constant.URL_BASE}${Constant.URL_GET_ROLES}`;

@Component({
  selector: 'srms-role-component',
  standalone: true,
  imports: [
    HttpClientModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatPaginatorModule,
    MatTableModule,
    MatTooltipModule,
  ],
  providers: [HttpService],
  templateUrl: './role.component.html',
  styleUrl: './role.component.scss',
})
export class RoleComponent implements OnInit {
  readonly displayedColumns: string[];
  dataSource = signal<IRole[]>([]);

  constructor(
    public dialog: MatDialog,
    public readonly httpService: HttpService
  ) {
    this.displayedColumns = ['position', 'name', 'description', 'disabled', 'actions'];
  }

  ngOnInit(): void {
    const pagination: IPagination = {
      Page: 1,
      Limit: 10,
    };
    const params = `Page=${encodeURIComponent(pagination.Page)}&Limit=${encodeURIComponent(pagination.Limit)}`;
    this.httpService.get<IRoles>(`${URL}?${params}`).subscribe({
      next: (data) => this.dataSource.update(() => data.roles),
      complete: () => console.log('Roles loaded'),
      error: (error) => console.error(error),
    });
  }

  openDialogNew(): void {
    this.dialog.open(RoleDialogComponent, {
      data: signal({ formType: FormType.CREATE }),
      width: '450px',
    });
  }

  openDialogEdit(role: IRole): void {
    this.dialog.open(RoleDialogComponent, {
      data: signal({ formType: FormType.EDIT, role }),
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
