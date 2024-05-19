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
import { RoleFormComponent } from '../role-form/role-form.component';
import { DialogType, FormType } from './dialog.type';

@Component({
    selector: 'srms-role-security-dialog',
    standalone: true,
    imports: [
        CommonModule,
        MatButtonModule,
        MatDialogModule,
        RoleFormComponent,
        SharedModule,
    ],
    providers: [HttpService],
    templateUrl: './role-dialog.component.html',
    styleUrl: './role-dialog.component.scss',
})
export class RoleDialogComponent implements OnInit {
    signal = signal;
    formType = signal(FormType);
    formRole!: Signal<FormGroup>;

    constructor(
        public dialogRef: MatDialogRef<RoleDialogComponent>,
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

    roleForm(form: Signal<FormGroup>): void {
        this.formRole = form;
    }
}
