import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private changeAuthSubject = new Subject<boolean>();
  public isAuth = this.changeAuthSubject.asObservable();

  constructor() {
    // TODO: Call API to check if user is authenticated with a token
  }

  reload() {
    this.changeAuthSubject.next(true);
  }
}
