import { Injectable, inject } from '@angular/core';
import { Subject, lastValueFrom } from 'rxjs';
import { Constant } from '../constants/constants';
import { HttpService } from './http.service';

const URL_VERIFY_TOKEN = `${Constant.URL_BASE}${Constant.URL_VERIFY_TOKEN}`;

@Injectable()
export class AuthService {
  private changeAuthSubject = new Subject<boolean>();
  public isAuthSubject = this.changeAuthSubject.asObservable();
  private isAuth!: boolean;
  private readonly httpService = inject(HttpService);

  constructor() {}

  async verifyToken(token: string) {
    try {
      await lastValueFrom(this.httpService.post(URL_VERIFY_TOKEN, { token }));
      this.ChangeIsAuth();
    } catch (error) {
      this.ChangeIsNotAuth();
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
