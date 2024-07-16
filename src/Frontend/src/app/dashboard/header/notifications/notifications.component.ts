import { Component } from '@angular/core';
import { MatBadgeModule } from '@angular/material/badge';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { NotificationsModalComponent } from './notifications-modal/notifications-modal.component';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'srms-notifications',
  standalone: true,
  imports: [MatIconModule, MatButtonModule, MatBadgeModule, MatDialogModule, MatTooltipModule],
  templateUrl: './notifications.component.html',
  styleUrl: './notifications.component.scss',
})
export class NotificationsComponent {
  constructor(private dialog: MatDialog) {}

  openDialog() {
    this.dialog.open(NotificationsModalComponent, {
      position: { top: '64px', right: '64px' },
      autoFocus: false,
      hasBackdrop: true,
      width: '400px',
    });
  }
}
