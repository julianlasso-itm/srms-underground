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
import { DialogType, FormType } from './dialog.type';
import { SkillDetailFormComponent } from '../skill-detail-form/skill-detail-form.component';

@Component({
    selector: 'srms-skill-detail-dialog',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatDialogModule,
        SkillDetailFormComponent,
        SharedModule,
    ],
    providers: [HttpService],
    templateUrl: './skill-detail-dialog.component.html',
    styleUrl: './skill-detail-dialog.component.scss',
})
export class SkillDetailDialogComponent implements OnInit {
    signal = signal;
    formType = signal(FormType);
    formSkill!: Signal<FormGroup>;

    constructor(
        public dialogRef: MatDialogRef<SkillDetailDialogComponent>,
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

    skillForm(form: Signal<FormGroup>): void {
        this.formSkill = form;
    }
}
