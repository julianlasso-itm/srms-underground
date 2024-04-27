import { HttpParams } from '@angular/common/http';
import { Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterModule } from '@angular/router';
import { DeleteDialogComponent } from '../../../shared/components/delete-dialog/delete-dialog.component';
import { Constant } from '../../../shared/constants/constants';
import { IPagination } from '../../../shared/interfaces/pagination.interface';
import { HttpService } from '../../../shared/services/http.service';
import { ReloadDataService } from '../../../shared/services/reload-data.service';
import { SharedModule } from '../../../shared/shared.module';
import { CountryDialogComponent } from '../country-dialog/country-dialog.component';
import { FormType } from '../country-dialog/dialog.type';
import { ICountries, ICountry } from './country.interface';

const URL_GET_COUNTRIES = `${Constant.URL_BASE}${Constant.URL_GET_COUNTRIES}`;
const URL_COUNTRY = `${Constant.URL_BASE}${Constant.URL_COUNTRY}`;
const MIN_LENGTH = 5;

@Component({
  selector: 'srms-country-component',
  standalone: true,
  imports: [
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatTableModule,
    MatTooltipModule,
    SharedModule,
    RouterModule,
  ],
  templateUrl: './country.component.html',
  styleUrl: './country.component.scss',
})
export class CountryComponent implements OnInit {
  readonly displayedColumns: string[];
  dataSource = signal<ICountry[]>([]);
  totalRecords = signal(0);
  pageSize = signal(MIN_LENGTH);
  loading: boolean;
  loadingTable: boolean;
  filter = signal('');
  loadingFromFilter = signal(false);

  private pageIndex: number;

  constructor(
    public dialog: MatDialog,
    public httpService: HttpService,
    public reloadDataService: ReloadDataService
  ) {
    this.displayedColumns = ['position', 'name', 'disabled', 'actions'];
    this.loading = false;
    this.loadingTable = false;
    this.pageIndex = 0;
  }

  ngOnInit(): void {
    this.getCountries();
    this.reloadDataService.changeData.subscribe((data) => {
      this.getCountries();
    });
  }

  openDialogNew(): void {
    this.dialog.open(CountryDialogComponent, {
      data: signal({ formType: FormType.CREATE }),
      width: '450px',
    });
  }

  openDialogEdit(country: ICountry): void {
    this.dialog.open(CountryDialogComponent, {
      data: signal({ formType: FormType.EDIT, country }),
      width: '450px',
    });
  }

  openDialogDelete(id: string): void {
    this.dialog.open(DeleteDialogComponent, {
      data: { url: URL_COUNTRY, id },
      width: '400px',
      autoFocus: false,
    });
  }

  private getCountries(loadingTable: boolean = false): void {
    this.tableLoadingTrue(loadingTable);
    const pagination: IPagination = {
      Page: this.pageIndex + 1,
      Limit: this.pageSize(),
    };
    let params = new HttpParams()
      .append('Page', pagination.Page.toString())
      .append('Limit', pagination.Limit.toString())
      .append('Sort', 'Name');
    if (this.filter().length > 0) {
      params = new HttpParams().appendAll({
        Page: pagination.Page.toString(),
        Limit: pagination.Limit.toString(),
        Filter: this.filter(),
        Sort: 'Name',
      });
    }
    this.httpService.get<ICountries>(URL_GET_COUNTRIES, params).subscribe({
      next: (data) => {
        console.log(data);
        if (data.countries !== null) {
          this.dataSource.update(() => data.countries);
          this.totalRecords.update(() => data.total);
        } else {
          this.dataSource.update(() => []);
          this.totalRecords.update(() => 0);
        }
      },
      complete: () => {
        this.tableLoadingFalse(loadingTable);
        this.loadingFromFilter.update(() => false);
        console.log('Countries loaded');
      },
      error: (error) => {
        this.tableLoadingFalse(loadingTable);
        this.loadingFromFilter.update(() => false);
        console.error(error);
      },
    });
  }

  handlePageEvent(paginator: PageEvent) {
    this.pageIndex = paginator.pageIndex;
    this.pageSize.update(() => paginator.pageSize);
    this.getCountries(true);
  }

  filterData(filter: string): void {
    this.filter.update(() => filter);
    this.loadingFromFilter.update(() => true);
    this.getCountries(true);
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
