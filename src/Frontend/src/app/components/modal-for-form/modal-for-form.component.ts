import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { FormComponent } from '../form';
import { IModalForForm } from './modal-for-form.interface';

@Component({
  selector: 'srms-modal-for-form',
  standalone: true,
  imports: [FormComponent, MatDialogModule, MatButtonModule],
  templateUrl: './modal-for-form.component.html',
  styleUrl: './modal-for-form.component.scss',
})
export class ModalForFormComponent {
  constructor(
    public dialogRef: MatDialogRef<ModalForFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IModalForForm
  ) {}
}
