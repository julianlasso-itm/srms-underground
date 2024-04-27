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
import { ProvinceFormComponent } from '../province-form/province-form.component';
import { DialogType, FormType } from './dialog.type';

@Component({
  selector: 'srms-province-dialog',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatDialogModule,
    ProvinceFormComponent,
    SharedModule,
  ],
  providers: [HttpService],
  templateUrl: './province-dialog.component.html',
  styleUrl: './province-dialog.component.scss',
})
export class ProvinceDialogComponent implements OnInit {
  signal = signal;
  formType = signal(FormType);
  formProvince!: Signal<FormGroup>;

  constructor(
    public dialogRef: MatDialogRef<ProvinceDialogComponent>,
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

  provinceForm(form: Signal<FormGroup>): void {
    this.formProvince = form;
  }
}
