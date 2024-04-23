import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { HttpService } from '../../services/http.service';
import { SharedModule } from '../../shared.module';
import type { IDeleteDialogData } from './delete-dialog-data.interface';
import { ReloadDataService } from '../../services/reload-data.service';

@Component({
  selector: 'srms-delete-dialog',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, SharedModule],
  providers: [HttpService],
  templateUrl: './delete-dialog.component.html',
  styleUrl: './delete-dialog.component.scss',
})
export class DeleteDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<DeleteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IDeleteDialogData,
    public httpService: HttpService,
    public reloadDataService: ReloadDataService,
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
      },
      complete: () => {
        console.log('complete delete');
      },
    });
  }
}
