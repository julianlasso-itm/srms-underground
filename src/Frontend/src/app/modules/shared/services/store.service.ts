import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class StoreService {
  set<Type>(key: string, value: Type): void {
    localStorage.setItem(key, JSON.stringify(value));
  }

  get<Type>(key: string): Type {
    return JSON.parse(localStorage.getItem(key) ?? '');
  }

  remove(key: string): void {
    localStorage.removeItem(key);
  }

  clear(): void {
    localStorage.clear();
  }

  getToken(): string {
    return this.get<string>('token');
  }

  setToken(token: string): void {
    this.set('token', token);
  }
}
