import { HttpParams } from '@angular/common/http';
import { Component, OnDestroy, OnInit, signal } from '@angular/core';
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
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { DeleteDialogComponent } from '../../../shared/components/delete-dialog/delete-dialog.component';
import { InputFilterComponent } from '../../../shared/components/input-filter/input-filter.component';
import { Constant } from '../../../shared/constants/constants';
import { IPagination } from '../../../shared/interfaces/pagination.interface';
import { HttpService } from '../../../shared/services/http.service';
import { ReloadDataService } from '../../../shared/services/reload-data.service';
import { SharedModule } from '../../../shared/shared.module';
import { CityDialogComponent } from '../city-dialog/city-dialog.component';
import { FormType } from '../city-dialog/dialog.type';
import { ICities, ICity } from './city.interface';

const URL_GET_CITIES = `${Constant.URL_BASE}${Constant.URL_GET_CITIES}`;
const URL_CITY = `${Constant.URL_BASE}${Constant.URL_CITY}`;
const MIN_LENGTH = 10;

@Component({
    selector: 'srms-city-component',
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
        InputFilterComponent,
    ],
    templateUrl: './city.component.html',
    styleUrl: './city.component.scss',
})
export class CityComponent implements OnInit, OnDestroy {
    readonly displayedColumns: string[];
    dataSource = signal<ICity[]>([]);
    totalRecords = signal(0);
    pageSize = signal(MIN_LENGTH);
    loading: boolean;
    loadingTable: boolean;
    filter = signal('');
    loadingFromFilter = signal(false);

    private pageIndex: number;
    private reloadData!: Subscription;

    constructor(
        public dialog: MatDialog,
        public httpService: HttpService,
        public reloadDataService: ReloadDataService,
        private activatedRoute: ActivatedRoute
    ) {
        this.displayedColumns = [
            'position',
            'name',
            'province',
            'disabled',
            'actions',
        ];
        this.loading = false;
        this.loadingTable = false;
        this.pageIndex = 0;
    }

    ngOnInit(): void {
        console.log(
            'ProvinceId: ',
            this.activatedRoute.snapshot.queryParams['provinceId']
        );
        this.getCities();
        this.reloadData = this.reloadDataService.changeData.subscribe(
            (data) => {
                this.getCities();
            }
        );
    }

    ngOnDestroy(): void {
        this.reloadData.unsubscribe();
    }

    openDialogNew(): void {
        this.dialog.open(CityDialogComponent, {
            data: signal({ formType: FormType.CREATE }),
            width: '450px',
        });
    }

    openDialogEdit(city: ICity): void {
        this.dialog.open(CityDialogComponent, {
            data: signal({ formType: FormType.EDIT, city }),
            width: '450px',
        });
    }

    openDialogDelete(id: string): void {
        this.dialog.open(DeleteDialogComponent, {
            data: { url: URL_CITY, id },
            width: '400px',
            autoFocus: false,
        });
    }

    private getCities(loadingTable: boolean = false): void {
        this.tableLoadingTrue(loadingTable);
        const pagination: IPagination = {
            Page: this.pageIndex + 1,
            Limit: this.pageSize(),
        };
        let params = new HttpParams()
            .append('Page', pagination.Page.toString())
            .append('Limit', pagination.Limit.toString());

        if (this.filter().length > 0) {
            params = new HttpParams().appendAll({
                Page: pagination.Page.toString(),
                Limit: pagination.Limit.toString(),
                Filter: this.filter(),
            });
        }
        this.httpService.get<ICities>(URL_GET_CITIES, params).subscribe({
            next: (data) => {
                console.log(data);
                if (data.cities !== null) {
                    this.dataSource.update(() => data.cities);
                    this.totalRecords.update(() => data.total);
                } else {
                    this.dataSource.update(() => []);
                    this.totalRecords.update(() => 0);
                }
            },
            complete: () => {
                this.tableLoadingFalse(loadingTable);
                this.loadingFromFilter.update(() => false);
                console.log('Cities loaded');
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
        this.getCities(true);
    }

    filterData(filter: string): void {
        this.filter.update(() => filter);
        this.loadingFromFilter.update(() => true);
        this.getCities(true);
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
