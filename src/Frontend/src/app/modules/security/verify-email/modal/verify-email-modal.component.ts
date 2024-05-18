import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { HttpService } from '../../../shared/services/http.service';

@Component({
  selector: 'srms-verify-email-modal',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatDialogModule,
    MatIconModule,
    RouterModule,
  ],
  providers: [HttpService],
  templateUrl: './verify-email-modal.component.html',
  styleUrl: './verify-email-modal.component.scss',
})
export class VerifyEmailModalComponent {}
