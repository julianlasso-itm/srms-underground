import {
  Component,
  Input,
  Output,
  Signal,
  computed,
  signal,
  EventEmitter,
  OnInit,
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
import { IRole } from '../role/role.interface';

@Component({
  selector: 'srms-role-form',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatSlideToggleModule,
    ReactiveFormsModule,
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

  constructor() {
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
        new FormControl<boolean>(!this.role()?.disabled || false) // cuando se guarde, se debe de invertir el valor
      );
    }
    this.form.emit(computed(() => this.frmRole()));
  }

  onSubmit(): void {
    console.log(this.frmRole().value);
  }
}
