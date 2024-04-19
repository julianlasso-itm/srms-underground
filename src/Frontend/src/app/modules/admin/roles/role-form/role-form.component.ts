import { CommonModule } from '@angular/common';
import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  Signal,
  computed,
  signal,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { Constant } from '../../../shared/constants/constants';
import { HttpService } from '../../../shared/services/http.service';
import { ReloadDataService } from '../../../shared/services/reload-data.service';
import { SharedModule } from '../../../shared/shared.module';
import { IRole } from '../role/role.interface';

const URL_ROLE = `${Constant.URL_BASE}${Constant.URL_ROLE}`;

@Component({
  selector: 'srms-role-form',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSlideToggleModule,
    ReactiveFormsModule,
    SharedModule,
  ],
  templateUrl: './role-form.component.html',
  styleUrl: './role-form.component.scss',
})
export class RoleFormComponent implements OnInit {
  @Input() role: Signal<IRole | null> = signal(null);
  @Output('frmRole') form: EventEmitter<Signal<FormGroup>>;
  public frmRole: Signal<FormGroup>;
  private regexp =
    '^[0-9A-Za-z]{8}-[0-9A-Za-z]{4}-4[0-9A-Za-z]{3}-[89ABab][0-9A-Za-z]{3}-[0-9A-Za-z]{12}$';

  constructor(
    public httpService: HttpService,
    public reloadDataService: ReloadDataService
  ) {
    this.frmRole = signal(
      new FormGroup({
        name: new FormControl('', [
          Validators.required,
          Validators.maxLength(50),
        ]),
        description: new FormControl('', [Validators.maxLength(1024)]),
      })
    );
    this.form = new EventEmitter<Signal<FormGroup>>();
  }

  ngOnInit(): void {
    if (this.role()?.roleId !== undefined) {
      this.frmRole().setControl(
        'roleId',
        new FormControl(this.role()?.roleId, [
          Validators.required,
          Validators.pattern(this.regexp),
        ])
      );
      this.frmRole().get('name')?.setValue(this.role()?.name);
      this.frmRole().get('description')?.setValue(this.role()?.description);
      this.frmRole().setControl(
        'disabled',
        new FormControl<boolean>(!this.role()?.disabled || false)
      );
    }
    this.form.emit(computed(() => this.frmRole()));
  }

  onSubmit(): void {
    if (this.frmRole().valid) {
      if (this.role()?.roleId === undefined) {
        this.createRole();
      } else {
        this.updateRole();
      }
    }
  }

  private createRole(): void {
    const body = this.frmRole().value;
    if (body.description === '') {
      delete body.description;
    }
    this.httpService.post(URL_ROLE, body).subscribe({
      next: (response) => {
        console.log(response);
        this.reloadDataService.reload();
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.log('complete');
      },
    });
  }

  private updateRole(): void {
    const body = this.frmRole().value;
    if (body.description === '') {
      body.description = null;
    }
    body.disable = !body.disabled;
    delete body.disabled;

    const url = `${URL_ROLE}/${this.role()?.roleId}`;
    delete body.roleId;

    this.httpService.put(url, body).subscribe({
      next: (response) => {
        console.log(response);
        this.reloadDataService.reload();
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.log('complete');
      },
    });
  }
}
