import { Component, Input, Signal, signal } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'srms-role-form',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule],
  templateUrl: './role-form.component.html',
  styleUrl: './role-form.component.scss',
})
export class RoleFormComponent {
  @Input() id: Signal<string | null>;

  constructor() {
    this.id = signal(null);
  }
}
