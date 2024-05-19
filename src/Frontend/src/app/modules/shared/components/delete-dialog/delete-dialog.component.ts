import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
    MAT_DIALOG_DATA,
    MatDialogModule,
    MatDialogRef,
} from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { HttpService } from '../../services/http.service';
import { ReloadDataService } from '../../services/reload-data.service';
import { SharedModule } from '../../shared.module';
import type { IDeleteDialogData } from './delete-dialog-data.interface';

@Component({
    selector: 'srms-delete-dialog',
    standalone: true,
    imports: [
        MatDialogModule,
        MatButtonModule,
        SharedModule,
        MatSnackBarModule,
    ],
    providers: [HttpService],
    templateUrl: './delete-dialog.component.html',
    styleUrl: './delete-dialog.component.scss',
})
export class DeleteDialogComponent {
    constructor(
        private dialogRef: MatDialogRef<DeleteDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: IDeleteDialogData,
        private httpService: HttpService,
        private reloadDataService: ReloadDataService,
        private snackBar: MatSnackBar
    ) {}

    onCancelClick(): void {
        this.dialogRef.close();
    }

    delete(): void {
        const url = `${this.data.url}/${this.data.id}`;
        this.httpService.delete(url).subscribe({
            next: () => {
                this.onCancelClick();
                this.reloadDataService.reload();
            },
            error: (err) => {
                console.error(err);
                this.handleException(err);
            },
            complete: () => {
                console.log('complete delete');
            },
        });
    }

    private handleException(error: any): void {
        const errorMessages = new Map([
            ['409_23505', 'El país que intentas crear ya existe'],
            [
                '409_23503',
                'No es posible eliminar un registro porque tiene otros registros asociados',
            ],
        ]);

        const errorKey = `${error.status}_${error.error.Errors.substring(
            0,
            5
        )}`;
        const message =
            errorMessages.get(errorKey) ??
            error.error.Errors ??
            'Error desconocido';

        this.snackBar.open(message, 'Cerrar', { duration: 5000 });
    }
}
