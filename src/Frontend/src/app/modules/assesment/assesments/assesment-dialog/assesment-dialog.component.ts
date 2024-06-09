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
import { AssesmentFormComponent } from '../assesment-form/assesment-form.component';
import { DialogType, FormType } from './dialog.type';

@Component({
    selector: 'srms-assesment-dialog',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatDialogModule,
        AssesmentFormComponent,
        SharedModule,
    ],
    providers: [HttpService],
    templateUrl: './assesment-dialog.component.html',
    styleUrl: './assesment-dialog.component.scss',
})
export class AssesmentDialogComponent implements OnInit {
    signal = signal;
    formType = signal(FormType);
    formAssesment!: Signal<FormGroup>;

    constructor(
        public dialogRef: MatDialogRef<AssesmentDialogComponent>,
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

    assesmentForm(form: Signal<FormGroup>): void {
        this.formAssesment = form;
    }
}
