import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private changeAuthSubject = new Subject<boolean>();
  public isAuthSubject = this.changeAuthSubject.asObservable();
  public isAuth = true; // TODO: Change to false

  constructor() {
    // TODO: Call API to check if user is authenticated with a token
  }

  reload() {
    this.isAuth = true;
    this.changeAuthSubject.next(this.isAuth);
  }
}
