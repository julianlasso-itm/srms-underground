import { HttpParams } from '@angular/common/http';
import { Component, OnInit, signal } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
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

const URL_GET_ROLES = `${Constant.URL_BASE}${Constant.URL_GET_ROLES}`;
const URL_ROLE = `${Constant.URL_BASE}${Constant.URL_ROLE}`;
const MIN_LENGTH = 5;

@Component({
  selector: 'srms-role-component',
  standalone: true,
  imports: [
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatPaginatorModule,
    MatProgressBarModule,
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
  totalRecords = signal(0);
  pageSize = signal(MIN_LENGTH);
  loading: boolean;
  loadingTable: boolean;

  private pageIndex: number;

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
    this.loading = false;
    this.loadingTable = false;
    this.pageIndex = 0;
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
      data: { url: URL_ROLE, id },
      width: '400px',
      autoFocus: false,
    });
  }

  private getRoles(loadingTable: boolean = false): void {
    this.tableLoadingTrue(loadingTable);
    const pagination: IPagination = {
      Page: this.pageIndex + 1,
      Limit: this.pageSize(),
    };
    const params = new HttpParams()
      .set('Page', pagination.Page)
      .set('Limit', pagination.Limit);
    this.httpService.get<IRoles>(URL_GET_ROLES, params).subscribe({
      next: (data) => {
        console.log(data);
        if (data.roles !== null) {
          this.dataSource.update(() => data.roles);
          this.totalRecords.update(() => data.total);
        } else {
          this.dataSource.update(() => []);
          this.totalRecords.update(() => 0);
        }
      },
      complete: () => {
        this.tableLoadingFalse(loadingTable);
        console.log('Roles loaded');
      },
      error: (error) => {
        this.tableLoadingFalse(loadingTable);
        console.error(error);
      },
    });
  }

  handlePageEvent(paginator: PageEvent) {
    console.log(paginator);
    this.pageIndex = paginator.pageIndex;
    this.pageSize.update(() => paginator.pageSize);
    this.getRoles(true);
  }

  private tableLoadingTrue(loadingTable: boolean): void {
    if (loadingTable) {
      this.loadingTable = true;
    } else {
      this.loading = true;
    }
  }

  private tableLoadingFalse(loadingTable: boolean): void {
    if (loadingTable) {
      this.loadingTable = false;
    } else {
      this.loading = false;
    }
  }
}
