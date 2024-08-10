import { CommonModule } from '@angular/common';
import { Component, Input, signal, WritableSignal } from '@angular/core';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FormField, TypeInput } from '../modal-for-form';

@Component({
  selector: 'srms-form',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatRadioModule,
    MatSelectModule,
    MatSlideToggleModule,
    MatTooltipModule,
    ReactiveFormsModule,
  ],
  templateUrl: './form.component.html',
  styleUrl: './form.component.scss',
})
export class FormComponent {
  @Input({ alias: 'form', required: true }) info: WritableSignal<
    Array<FormField>
  >;
  @Input({ required: true }) data: object;
  form: WritableSignal<FormGroup>;
  type = TypeInput;

  constructor() {
    this.form = signal(new FormGroup({}));
    this.info = signal([]);
    this.data = {};
  }

  ngOnInit(): void {
    this.createForm();
    this.form().valueChanges.subscribe((value) => {
      console.log(value);
    });
  }

  createForm(): void {
    const form = new FormGroup({});
    if (this.info().length > 0) {
      this.info().forEach((field) => {
        if (field.formControl) {
          form.addControl(field.field, field.formControl());
        }
      });
    }
    this.form.set(form);
  }

  getOptions(field: FormField): Array<object> {
    if (field.loadOptions) return field.loadOptions();
    return [];
  }

  getOptionValue(option: object): string {
    return (option as any).value;
  }

  getOptionLabel(option: object): string {
    return (option as any).label;
  }
}
