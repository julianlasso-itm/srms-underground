import { CommonModule } from '@angular/common';
import { Component, Inject, OnInit, Signal, signal } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { HttpService } from '../../../shared/services/http.service';
import { ReloadDataService } from '../../../shared/services/reload-data.service';
import { SharedModule } from '../../../shared/shared.module';
import { ProfessionalFormComponent } from '../professional-form/professional-form.component';
import { DialogType, FormType } from './dialog.type';

@Component({
  selector: 'srms-professional-dialog',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatDialogModule,
    ProfessionalFormComponent,
    SharedModule,
  ],
  providers: [HttpService],
  templateUrl: './professional-dialog.component.html',
  styleUrl: './professional-dialog.component.scss',
})
export class ProfessionalDialogComponent implements OnInit {
  signal = signal;
  formType = signal(FormType);
  formProfessional!: Signal<FormGroup>;

  constructor(
    public dialogRef: MatDialogRef<ProfessionalDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Signal<DialogType>,
    public reloadDataService: ReloadDataService
  ) {}

  ngOnInit(): void {
    this.reloadDataService.changeData.subscribe((data) => {
      this.dialogRef.close();
    });
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  professionalForm(form: Signal<FormGroup>): void {
    this.formProfessional = form;
  }
}
