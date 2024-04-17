import { Component, Inject } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import type { IDeleteDialogData } from './delete-dialog-data.interface';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'srms-delete-dialog',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule],
  templateUrl: './delete-dialog.component.html',
  styleUrl: './delete-dialog.component.scss',
})
export class DeleteDialogComponent {
  constructor(
    public readonly dialogRef: MatDialogRef<DeleteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IDeleteDialogData
  ) {}

  onCancelClick(): void {
    this.dialogRef.close();
  }

  delete(): void {
    console.log('delete', this.data.url, this.data.id);
    this.dialogRef.close();
  }
}
