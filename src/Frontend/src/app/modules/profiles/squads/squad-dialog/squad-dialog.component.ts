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
import { SquadFormComponent } from '../squad-form/squad-form.component';
import { DialogType, FormType } from './dialog.type';

@Component({
    selector: 'srms-squad-dialog',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatDialogModule,
        SquadFormComponent,
        SharedModule,
    ],
    providers: [HttpService],
    templateUrl: './squad-dialog.component.html',
    styleUrl: './squad-dialog.component.scss',
})
export class SquadDialogComponent implements OnInit {
    signal = signal;
    formType = signal(FormType);
    formSquad!: Signal<FormGroup>;

    constructor(
        public dialogRef: MatDialogRef<SquadDialogComponent>,
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

    squadForm(form: Signal<FormGroup>): void {
        this.formSquad = form;
    }
}
