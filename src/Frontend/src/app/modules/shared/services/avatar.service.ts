import { Injectable, inject } from '@angular/core';
import { Subject } from 'rxjs';
import { StoreService } from './store.service';

@Injectable()
export class AvatarService {
    private avatar: string = '';
    private storeService = inject(StoreService);
    private changeAvatarSubject = new Subject<string>();
    public avatarSubject = this.changeAvatarSubject.asObservable();

    constructor() {
        if (this.storeService.get('avatar') !== '') {
            this.avatar = this.storeService.get('avatar');
        }
    }

    get() {
        return this.avatar;
    }

    set(avatar: string) {
        this.avatar = avatar;
        this.storeService.set('avatar', avatar);
        this.changeAvatarSubject.next(avatar);
    }

    remove() {
        this.avatar = '';
        this.storeService.remove('avatar');
        this.changeAvatarSubject.next('');
    }
}
