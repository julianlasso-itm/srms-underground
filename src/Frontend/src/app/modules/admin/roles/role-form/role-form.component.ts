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

@Component({
  selector: 'srms-role-form',
  standalone: true,
  imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule],
  templateUrl: './role-form.component.html',
  styleUrl: './role-form.component.scss',
})
export class RoleFormComponent implements OnInit {
  @Input() id: Signal<string | null>;
  @Output('frmRole') form: EventEmitter<Signal<FormGroup>>;
  public frmRole: Signal<FormGroup>;
  private regexp =
    '^[0-9A-Za-z]{8}-[0-9A-Za-z]{4}-4[0-9A-Za-z]{3}-[89ABab][0-9A-Za-z]{3}-[0-9A-Za-z]{12}$';

  constructor() {
    this.id = signal(null);
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
    if (this.id() !== null) {
      this.frmRole().setControl(
        'id',
        new FormControl(this.id(), [
          Validators.required,
          Validators.pattern(this.regexp),
        ])
      );
    }
    this.form.emit(computed(() => this.frmRole()));
  }
}
