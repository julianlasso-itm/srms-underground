import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReloadDataService {
  private reloadSubject = new Subject<boolean>();
  public changeData = this.reloadSubject.asObservable();

  reload() {
    this.reloadSubject.next(true);
  }
}
