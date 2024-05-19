import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { StoreService } from './store.service';

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
  constructor(
    private readonly storeService: StoreService,
    private readonly authService: AuthService
  ) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = this.storeService.getToken();
    if (
      token !== '' &&
      token.length > 0 &&
      this.authService.isAuthenticated()
    ) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }
    return next.handle(req);
  }
}
