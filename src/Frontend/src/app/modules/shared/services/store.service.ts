import { Injectable } from '@angular/core';

@Injectable()
export class StoreService {
  set<Type>(key: string, value: Type): void {
    if (typeof value === 'object') {
      localStorage.setItem(key, JSON.stringify(value));
      return;
    }
    localStorage.setItem(key, String(value));
  }

  get<Type>(key: string): Type {
    try {
      return JSON.parse(localStorage.getItem(key) ?? '');
    } catch {
      return (localStorage.getItem(key) as Type) ?? ('' as Type);
    }
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

  clearToken(): void {
    this.remove('token');
  }
}
