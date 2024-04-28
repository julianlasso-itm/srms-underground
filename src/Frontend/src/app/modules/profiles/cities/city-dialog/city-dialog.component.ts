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
import { CityFormComponent } from '../city-form/city-form.component';
import { DialogType, FormType } from './dialog.type';

@Component({
  selector: 'srms-city-dialog',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatDialogModule,
    CityFormComponent,
    SharedModule,
  ],
  providers: [HttpService],
  templateUrl: './city-dialog.component.html',
  styleUrl: './city-dialog.component.scss',
})
export class CityDialogComponent implements OnInit {
  signal = signal;
  formType = signal(FormType);
  formCity!: Signal<FormGroup>;

  constructor(
    public dialogRef: MatDialogRef<CityDialogComponent>,
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

  cityForm(form: Signal<FormGroup>): void {
    this.formCity = form;
  }
}
