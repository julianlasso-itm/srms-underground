import { Component, Inject, signal, type Signal } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { DialogType, FormType } from './dialog.type';
import { RoleFormComponent } from '../role-form/role-form.component';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'srms-role-dialog',
  standalone: true,
  imports: [MatButtonModule, MatDialogModule, RoleFormComponent],
  templateUrl: './role-dialog.component.html',
  styleUrl: './role-dialog.component.scss',
})
export class RoleDialogComponent {
  signal = signal;
  formType = signal(FormType);

  constructor(
    public readonly dialogRef: MatDialogRef<RoleDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Signal<DialogType>
  ) {}

  onCancelClick(): void {
    this.dialogRef.close();
  }
}
