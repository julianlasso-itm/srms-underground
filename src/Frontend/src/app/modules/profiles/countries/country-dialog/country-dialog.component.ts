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
import { CountryFormComponent } from '../country-form/country-form.component';
import { DialogType, FormType } from './dialog.type';

@Component({
  selector: 'srms-country-dialog',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatDialogModule,
    CountryFormComponent,
    SharedModule,
  ],
  providers: [HttpService],
  templateUrl: './country-dialog.component.html',
  styleUrl: './country-dialog.component.scss',
})
export class CountryDialogComponent implements OnInit {
  signal = signal;
  formType = signal(FormType);
  formCountry!: Signal<FormGroup>;

  constructor(
    public dialogRef: MatDialogRef<CountryDialogComponent>,
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

  countryForm(form: Signal<FormGroup>): void {
    this.formCountry = form;
  }
}
