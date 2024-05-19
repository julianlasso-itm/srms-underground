import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Constant } from '../../../shared/constants/constants';
import { HttpService } from '../../../shared/services/http.service';
import { VerifyEmailModalComponent } from '../modal/verify-email-modal.component';

const URL_ACTIVATE_ACCOUNT = `${Constant.URL_BASE}${Constant.URL_ACTIVATE_ACCOUNT}`;

@Component({
  selector: 'srms-verify-email',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './verify-email.component.html',
  styleUrl: './verify-email.component.scss',
})
export class VerifyEmailComponent implements OnInit, OnDestroy {
  private dialogRef!: MatDialogRef<VerifyEmailModalComponent>;
  private susses!: boolean;
  private token: string;

  constructor(
    private dialog: MatDialog,
    private readonly httpService: HttpService,
    private readonly activatedRoute: ActivatedRoute
  ) {
    this.token = activatedRoute.snapshot.params['token'];
  }

  ngOnInit(): void {
    this.httpService.get(`${URL_ACTIVATE_ACCOUNT}/${this.token}`).subscribe({
      next: () => {
        this.susses = true;
        this.dialogRef = this.dialog.open(VerifyEmailModalComponent, {
          width: '450px',
          disableClose: true,
          data: { susses: this.susses },
        });
      },
      error: () => {
        this.susses = false;
        this.dialogRef = this.dialog.open(VerifyEmailModalComponent, {
          width: '450px',
          disableClose: true,
          data: { susses: this.susses },
        });
      },
    });
  }

  ngOnDestroy(): void {
    this.dialogRef.close();
  }
}
