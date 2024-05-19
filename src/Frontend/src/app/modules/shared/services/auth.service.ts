import { Injectable, inject } from '@angular/core';
import { Subject, lastValueFrom } from 'rxjs';
import { Constant } from '../constants/constants';
import { HttpService } from './http.service';
import { StoreService } from './store.service';
import { ProfileModel } from '../../user/profile/profile.dto';

const URL_VERIFY_TOKEN = `${Constant.URL_BASE}${Constant.URL_VERIFY_TOKEN}`;

@Injectable()
export class AuthService {
  private changeAuthSubject = new Subject<boolean>();
  public isAuthSubject = this.changeAuthSubject.asObservable();
  private isAuth!: boolean;
  private profile!: ProfileModel;
  private readonly httpService = inject(HttpService);

  constructor(private storeService: StoreService) {}

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

  getUserAutenticated() {
    return this.profile;
  }

  ChangeIsAuth() {
    this.isAuth = true;
    this.profile = this.getTokenData();
    this.changeAuthSubject.next(this.isAuth);
  }

  ChangeIsNotAuth() {
    this.isAuth = false;
    this.profile = new ProfileModel();
    this.changeAuthSubject.next(this.isAuth);
  }

  signOut() {
    this.ChangeIsNotAuth();
  }

  getTokenData() {
    let token = this.storeService.getToken();
    if (token !== '' && token.length > 0) {
      const dataBase64 = token.split('.')[1];
      return JSON.parse(atob(dataBase64));
    }
  }
}
