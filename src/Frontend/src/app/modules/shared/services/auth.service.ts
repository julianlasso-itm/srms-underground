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

  ChangeIsAuth() {
    this.isAuth = true;
    this.changeAuthSubject.next(this.isAuth);
  }

  ChangeIsNotAuth() {
    this.isAuth = false;
    this.changeAuthSubject.next(this.isAuth);
  }

  signOut() {
    this.ChangeIsNotAuth();
  }

  getTokenData() {
    //TODO: Remove this line
    //localStorage.setItem('token','eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJUb2tlbklkIjoiMWUyMTU4NGItYWQ3MC00OGU2LWI1ZDItYjE4NDFiMGJhZjc0IiwiTmFtZSI6Ikp1bGlhbiBMYXNzbyIsIkVtYWlsIjoianVsaWFuLmxhc3NvXHUwMDJCMUBnbWFpbC5jb20iLCJQaG90byI6Imh0dHBzOi8vb3JkZXJzenVsdTIwMjQuYmxvYi5jb3JlLndpbmRvd3MubmV0L3VzZXJzL1NSTVMtNjU4N2E1MGQtNjczYi00ODEyLWE5OGQtNDRiODgwMGQzNmMzLndlYnAiLCJSb2xlcyI6WyJVc2VyIl0sIkV4cGlyYXRpb24iOjE3MTYxMjc4NzJ9.ZaHX8bNRpBpFeGtdSuIoGWCzmgMwmgiZ1ZS9QZwIuL8MK7U2Nh1yt-q-ijqq5b-0ZzA1dViIjHEXV7K5rRfRzJeFXSEra_ktO1mUGz017rS8Juskp-JxYx251ZyOkhA1g2Vb8clQWqzdWvwD_rFnie2oS58ObfYoGeQA2rfwlULpu6tQRu0kCzXvuoKrRGjaX4SXLTOJLHRQGzfrhVo3NybSdsvgMwyWqxLmFt4vwVM4hpExAYQp82_bT8DC4yl1yAEHdNmugomhvUL-CTiH4SeGfiCyXaPt1JSd58MQ2sMHCQ-pVCIZmlRLMs10TdjXhQAOXgOWJmmcFxBK28xtfQ');
    let token = this.storeService.getToken();
    if (token !== '' && token.length > 0) {
      const dataBase64 = token.split('.')[1];
      return JSON.parse(atob(dataBase64));
    }
  }
}
