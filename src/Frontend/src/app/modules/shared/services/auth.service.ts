import { Injectable, inject } from '@angular/core';
import { Subject, lastValueFrom } from 'rxjs';
import { ProfileModel } from '../../user/profile/profile.dto';
import { Constant } from '../constants/constants';
import { AvatarService } from './avatar.service';
import { HttpService } from './http.service';
import { StoreService } from './store.service';
import { NameService } from './name.service';

const URL_VERIFY_TOKEN = `${Constant.URL_BASE}${Constant.URL_VERIFY_TOKEN}`;

@Injectable()
export class AuthService {
    private changeAuthSubject = new Subject<boolean>();
    public isAuthSubject = this.changeAuthSubject.asObservable();
    private isAuth!: boolean;
    private profile!: ProfileModel;
    private readonly httpService = inject(HttpService);
    private readonly avatarService = inject(AvatarService);
    private readonly nameService = inject(NameService);

    constructor(private storeService: StoreService) {}

    async verifyToken(token: string) {
        try {
            await lastValueFrom(
                this.httpService.post(URL_VERIFY_TOKEN, { token })
            );
            this.ChangeIsAuth();
        } catch (error) {
            this.ChangeIsNotAuth();
        }
    }

    isAuthenticated() {
        return this.isAuth;
    }

    getUserAuthenticated() {
        return this.profile;
    }

    ChangeIsAuth() {
        this.isAuth = true;
        this.profile = this.getTokenData();
        this.changeAuthSubject.next(this.isAuth);

        const avatar = localStorage.getItem('avatar');
        if (avatar == null) {
          this.avatarService.set(this.profile.Photo);
        } else {
          this.avatarService.set(avatar);
        }

        const name = localStorage.getItem('name');
        if (name == null) {
          this.nameService.set(this.profile.Name);
        } else {
          this.nameService.set(name);
        }
    }

    ChangeIsNotAuth() {
        this.isAuth = false;
        this.profile = new ProfileModel();
        this.changeAuthSubject.next(this.isAuth);
        this.avatarService.remove();
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
