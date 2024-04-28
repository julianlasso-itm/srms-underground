import {
  Component,
  EventEmitter,
  Input,
  Output,
  signal,
  Signal,
} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressBarModule } from '@angular/material/progress-bar';

@Component({
  selector: 'srms-input-filter',
  standalone: true,
  imports: [
    FormsModule,
    MatInputModule,
    MatProgressBarModule,
    MatFormFieldModule,
  ],
  templateUrl: './input-filter.component.html',
  styleUrl: './input-filter.component.scss',
})
export class InputFilterComponent {
  @Input() loadingTable: boolean;
  @Input() loadingFromFilter: Signal<boolean> = signal(false);
  @Input() filter: Signal<string> = signal('');
  @Output() filterData = new EventEmitter<string>();

  constructor() {
    this.loadingTable = false;
  }

  onFilterChange(value: string): void {
    this.filterData.emit(value);
  }
}
