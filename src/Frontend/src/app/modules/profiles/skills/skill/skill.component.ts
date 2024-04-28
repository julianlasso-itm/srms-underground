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
import { Subscription } from 'rxjs';
import { DeleteDialogComponent } from '../../../shared/components/delete-dialog/delete-dialog.component';
import { Constant } from '../../../shared/constants/constants';
import { IPagination } from '../../../shared/interfaces/pagination.interface';
import { HttpService } from '../../../shared/services/http.service';
import { ReloadDataService } from '../../../shared/services/reload-data.service';
import { SharedModule } from '../../../shared/shared.module';
import { FormType } from '../skill-dialog/dialog.type';
import { SkillDialogComponent } from '../skill-dialog/skill-dialog.component';
import { ISkill, ISkills } from './skill.interface';

const URL_GET_SKILLS = `${Constant.URL_BASE}${Constant.URL_GET_SKILLS}`;
const URL_SKILL = `${Constant.URL_BASE}${Constant.URL_SKILL}`;
const MIN_LENGTH = 5;

@Component({
  selector: 'srms-skill-component',
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
  ],
  templateUrl: './skill.component.html',
  styleUrl: './skill.component.scss',
})
export class SkillComponent implements OnInit, OnDestroy {
  readonly displayedColumns: string[];
  dataSource = signal<ISkill[]>([]);
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
    public reloadDataService: ReloadDataService
  ) {
    this.displayedColumns = ['name', 'disabled', 'actions'];
    this.loading = false;
    this.loadingTable = false;
    this.pageIndex = 0;
  }

  ngOnInit(): void {
    this.getSkills();
    this.reloadData = this.reloadDataService.changeData.subscribe((data) => {
      this.getSkills();
    });
  }

  ngOnDestroy(): void {
    this.reloadData.unsubscribe();
  }

  openDialogNew(): void {
    this.dialog.open(SkillDialogComponent, {
      data: signal({ formType: FormType.CREATE }),
      width: '450px',
    });
  }

  openDialogEdit(skill: ISkill): void {
    this.dialog.open(SkillDialogComponent, {
      data: signal({ formType: FormType.EDIT, skill }),
      width: '450px',
    });
  }

  openDialogDelete(id: string): void {
    this.dialog.open(DeleteDialogComponent, {
      data: { url: URL_SKILL, id },
      width: '400px',
      autoFocus: false,
    });
  }

  private getSkills(loadingTable: boolean = false): void {
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
    this.httpService.get<ISkills>(URL_GET_SKILLS, params).subscribe({
      next: (data) => {
        console.log(data);
        if (data.skills !== null) {
          this.dataSource.update(() => data.skills);
          console.log(data);
          this.totalRecords.update(() => data.total);
        } else {
          this.dataSource.update(() => []);
          this.totalRecords.update(() => 0);
        }
      },
      complete: () => {
        this.tableLoadingFalse(loadingTable);
        this.loadingFromFilter.update(() => false);
        console.log('Skills loaded');
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
    this.getSkills(true);
  }

  filterData(filter: string): void {
    this.filter.update(() => filter);
    this.loadingFromFilter.update(() => true);
    this.getSkills(true);
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
