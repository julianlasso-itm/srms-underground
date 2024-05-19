import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Constant } from '../../modules/shared/constants/constants';
import { AuthService } from '../../modules/shared/services/auth.service';
import { AvatarService } from '../../modules/shared/services/avatar.service';
import { NameService } from '../../modules/shared/services/name.service';

@Component({
    selector: 'srms-root',
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
    isAuth: boolean;
    avatar: string;
    name: string;
    private authObservable!: Subscription;

    constructor(
        private authService: AuthService,
        private avatarService: AvatarService,
        private nameService: NameService
    ) {
        this.isAuth = this.authService.isAuthenticated();
        this.avatar = this.avatarService.get();
        this.name = this.nameService.get();
    }

    ngOnInit() {
        this.authObservable = this.authService.isAuthSubject.subscribe(
            (isAuth) => {
                this.isAuth = isAuth;
            }
        );
        this.avatarService.avatarSubject.subscribe((avatar) => {
            this.avatar = avatar;
        });
        this.nameService.nameSubject.subscribe((name) => {
            this.name = name;
        });
    }

    getProfile() {
        return this.authService.getUserAuthenticated();
    }

    isAdmin(): boolean {
        return this.authService
            .getUserAuthenticated()
            .Roles.includes(Constant.ADMIN_ROLE);
    }
}
