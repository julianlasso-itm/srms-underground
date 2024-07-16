import { provideHttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { OAuthStorage, provideOAuthClient } from 'angular-oauth2-oidc';
import { AppRoutingModule } from './app-routing.module';

import { AuthStorageService } from './services/auth-storage.service';

import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

import { LoginComponent } from './login/login.component';
import { AppComponent } from './template/app.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatButtonModule,
    MatIconModule,
  ],
  providers: [
    provideHttpClient(),
    provideOAuthClient(),
    provideAnimationsAsync(),
    {
      provide: OAuthStorage,
      useFactory: () => AuthStorageService,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
