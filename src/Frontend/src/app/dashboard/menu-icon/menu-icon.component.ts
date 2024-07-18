import { CommonModule } from '@angular/common';
import { Component, HostBinding } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'srms-menu-icon',
  standalone: true,
  imports: [CommonModule, MatIconModule, MatButtonModule, MatTooltipModule],
  templateUrl: './menu-icon.component.html',
  styleUrl: './menu-icon.component.scss',
})
export class MenuIconComponent {
  @HostBinding('class.menu-visible') isMenuVisible = true;
  @HostBinding('class.menu-hidden') isMenuHidden = false;

  menuToggle() {
    this.isMenuVisible = !this.isMenuVisible;
    this.isMenuHidden = !this.isMenuHidden;
  }
}
