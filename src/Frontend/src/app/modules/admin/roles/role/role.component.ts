import { Component, OnInit, signal } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { DeleteDialogComponent } from '../../../shared/components/delete-dialog/delete-dialog.component';
import { Constant } from '../../../shared/constants/constants';
import { IPagination } from '../../../shared/interfaces/pagination.interface';
import { HttpService } from '../../../shared/services/http.service';
import { ReloadDataService } from '../../../shared/services/reload-data.service';
import { SharedModule } from '../../../shared/shared.module';
import { FormType } from '../role-dialog/dialog.type';
import { RoleDialogComponent } from '../role-dialog/role-dialog.component';
import { IRole, IRoles } from './role.interface';
import { HttpParams } from '@angular/common/http';

const URL_GET = `${Constant.URL_BASE}${Constant.URL_GET_ROLES}`;
const URL_DELETE = `${Constant.URL_BASE}${Constant.URL_DELETE_ROLE}`;

@Component({
  selector: 'srms-role-component',
  standalone: true,
  imports: [
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatPaginatorModule,
    MatTableModule,
    MatTooltipModule,
    SharedModule,
  ],
  templateUrl: './role.component.html',
  styleUrl: './role.component.scss',
})
export class RoleComponent implements OnInit {
  readonly displayedColumns: string[];
  dataSource = signal<IRole[]>([]);

  constructor(
    public dialog: MatDialog,
    public httpService: HttpService,
    public reloadDataService: ReloadDataService
  ) {
    this.displayedColumns = [
      'position',
      'name',
      'description',
      'disabled',
      'actions',
    ];
  }

  ngOnInit(): void {
    this.getRoles();
    this.reloadDataService.changeData.subscribe((data) => {
        this.getRoles();
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
      data: { url: URL_DELETE, id },
      width: '400px',
      autoFocus: false,
    });
  }

  private getRoles(): void {
    const pagination: IPagination = {
      Page: 1,
      Limit: 10,
    };
    const params = new HttpParams().set('Page', pagination.Page).set('Limit', pagination.Limit);
    this.httpService.get<IRoles>(URL_GET, params).subscribe({
      next: (data) => {
        console.log(data);
        if (data.roles !== null) {
          this.dataSource.update(() => data.roles);
        } else {
          this.dataSource.update(() => []);
        }
      },
      complete: () => console.log('Roles loaded'),
      error: (error) => console.error(error),
    });
  }
}
