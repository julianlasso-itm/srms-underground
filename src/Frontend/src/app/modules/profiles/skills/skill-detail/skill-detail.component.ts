import { Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { SharedModule } from '../../../shared/shared.module';
import { InputFilterComponent } from '../../../shared/components/input-filter/input-filter.component';
import { Subscription } from 'rxjs';
import { ISkill, ISkills, ISubSkill, ISubSkills } from '../skill/skill.interface';
import { SkillDetailDialogComponent } from '../skill-detail-dialog/skill-detail-dialog.component';
import { FormType } from '../skill-dialog/dialog.type';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from '../../../shared/components/delete-dialog/delete-dialog.component';
import { Constant } from '../../../shared/constants/constants';
import { IPagination } from '../../../shared/interfaces/pagination.interface';
import { HttpParams } from '@angular/common/http';
import { HttpService } from '../../../shared/services/http.service';
import { ReloadDataService } from '../../../shared/services/reload-data.service';

const URL_GET_SKILL_DETAILS = `${Constant.URL_BASE}${Constant.URL_GET_SKILLS_DETAILS}`;
const URL_SKILL_DETAILS = `${Constant.URL_BASE}${Constant.URL_SKILL_DETAIL}`;
const MIN_LENGTH = 10;

@Component({
  selector: 'srms-skill-detail',
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
    RouterModule,
  ],
  templateUrl: './skill-detail.component.html',
  styleUrl: './skill-detail.component.scss',
})
export class SkillDetailComponent implements OnInit {
  private idSkill: string = '';
  readonly displayedColumns: string[];
  dataSource = signal<ISubSkill[]>([]);
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
    private route: ActivatedRoute,
    private readonly router: Router,
    public httpService: HttpService,
    public reloadDataService: ReloadDataService,
  ) {
    this.idSkill = this.route.snapshot.paramMap.get('id')!;
    this.displayedColumns = ['position', 'name', 'disabled', 'actions'];
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
    this.dialog.open(SkillDetailDialogComponent, {
      data: signal({ formType: FormType.CREATE, skillId: this.idSkill }),
      width: '450px',
    });
  }

  openDialogEdit(skill: ISubSkill): void {
    this.dialog.open(SkillDetailDialogComponent, {
      data: signal({ formType: FormType.EDIT, skillId: skill.skillId}),
      width: '450px',
    });
  }

  openDialogDelete(id: string): void {
    this.dialog.open(DeleteDialogComponent, {
      data: { url: URL_SKILL_DETAILS, id },
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
      .append('Limit', pagination.Limit.toString())
      .append('Filter', this.idSkill)
      .append('FilterBy','SkillId');
    if (this.filter().length > 0) {
      params = new HttpParams().appendAll({
        Page: pagination.Page.toString(),
        Limit: pagination.Limit.toString(),
        Filter: this.filter(),
      });
    }
    this.httpService.get<ISubSkills>(URL_GET_SKILL_DETAILS, params).subscribe({
      next: (data) => {
        console.log(data);
        if (data.subSkills !== null) {
          this.dataSource.update(() => data.subSkills);
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
