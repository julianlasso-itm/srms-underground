import { Component, Inject, signal, Signal, type Output } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { DialogType, FormType } from './dialog.type';
import { RoleFormComponent } from '../role-form/role-form.component';
import { MatButtonModule } from '@angular/material/button';
import { HttpService } from '../../../shared/services/http.service';
import { HttpClientModule } from '@angular/common/http';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'srms-role-dialog',
  standalone: true,
  imports: [
    MatButtonModule,
    MatDialogModule,
    RoleFormComponent,
    HttpClientModule,
  ],
  providers: [HttpService],
  templateUrl: './role-dialog.component.html',
  styleUrl: './role-dialog.component.scss',
})
export class RoleDialogComponent {
  signal = signal;
  formType = signal(FormType);
  formRole!: Signal<FormGroup>;

  constructor(
    public readonly dialogRef: MatDialogRef<RoleDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Signal<DialogType>,
    public readonly httpService: HttpService
  ) {}

  onCancelClick(): void {
    this.dialogRef.close();
  }

  roleForm(form: Signal<FormGroup>): void {
    this.formRole = form;
  }
}
