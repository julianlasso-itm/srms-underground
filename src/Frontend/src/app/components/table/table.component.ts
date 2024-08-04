import {
  Component,
  computed,
  EventEmitter,
  Input,
  OnInit,
  Output,
  signal,
  Signal,
  WritableSignal,
} from '@angular/core';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { IDisplayedColumn } from './displayed-columns.interface';

@Component({
  selector: 'srms-table',
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss',
})
export class TableComponent implements OnInit {
  @Input() columns: Signal<IDisplayedColumn[]>;
  @Input() dataSource: WritableSignal<Object[]>;
  @Output() pageEvent: EventEmitter<PageEvent>;

  displayedColumns: Signal<string[]>;

  constructor() {
    this.columns = signal([]);
    this.dataSource = signal([{}]);
    this.displayedColumns = signal([]);
    this.pageEvent = new EventEmitter<PageEvent>();
  }

  ngOnInit(): void {
    this.displayedColumns = computed(() =>
      this.columns().map((column: IDisplayedColumn) => column.name)
    );
  }

  getElementColumn(element: any, index: number) {
    return element[this.columns()[index].field];
  }

  handlePageEvent(event: PageEvent) {
    this.pageEvent.emit(event);
  }
}
