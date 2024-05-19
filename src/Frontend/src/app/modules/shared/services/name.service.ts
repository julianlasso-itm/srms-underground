import { Injectable, inject } from '@angular/core';
import { Subject } from 'rxjs';
import { StoreService } from './store.service';

const KEY = 'name';

@Injectable()
export class NameService {
    private name: string = '';
    private storeService = inject(StoreService);
    private changeNameSubject = new Subject<string>();
    public nameSubject = this.changeNameSubject.asObservable();

    constructor() {
        if (this.storeService.get(KEY) !== '') {
            this.name = this.storeService.get(KEY);
        }
    }

    get() {
        return this.name;
    }

    set(name: string) {
        this.name = name;
        this.storeService.set(KEY, name);
        this.changeNameSubject.next(name);
    }

    remove() {
        this.name = '';
        this.storeService.remove(KEY);
        this.changeNameSubject.next('');
    }
}
