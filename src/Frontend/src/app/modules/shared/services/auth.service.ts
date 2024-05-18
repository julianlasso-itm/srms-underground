import { Injectable, inject } from '@angular/core';
import { Subject } from 'rxjs';
import { HttpService } from './http.service';
import { StoreService } from './store.service';
import { Constant } from '../constants/constants';

const URL_VERIFY_TOKEN = `${Constant.URL_BASE}${Constant.URL_VERIFY_TOKEN}`;

@Injectable()
export class AuthService {
  private changeAuthSubject = new Subject<boolean>();
  public isAuthSubject = this.changeAuthSubject.asObservable();
  private isAuth = false;

  private readonly storeService = inject(StoreService);
  private readonly httpService = inject(HttpService);

  constructor() {

    const token = this.storeService.getToken();
    if (token !== null && token.length > 0) {
      this.httpService.post(URL_VERIFY_TOKEN, { token }).subscribe({
        next: (response) => {
          this.ChangeIsAuth();
        },
        error: (error) => {
          this.ChangeIsNotAuth();
        },
      });
    }
  }

  isAuthenticated() {
    return this.isAuth;
  }

  ChangeIsAuth() {
    this.isAuth = true;
    this.changeAuthSubject.next(this.isAuth);
  }

  ChangeIsNotAuth() {
    this.isAuth = false;
    this.changeAuthSubject.next(this.isAuth);
  }
}
