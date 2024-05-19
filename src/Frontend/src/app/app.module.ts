import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, RouterOutlet } from '@angular/router';
import { AppRoutingModule } from './app.routes';
import { AuthInterceptorService } from './modules/shared/services/auth-interceptor.service';
import { AuthService } from './modules/shared/services/auth.service';
import { AvatarService } from './modules/shared/services/avatar.service';
import { HttpService } from './modules/shared/services/http.service';
import { StoreService } from './modules/shared/services/store.service';
import { ProfileComponent } from './modules/user/profile/profile.component';
import { AppComponent } from './templates/main/app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    CommonModule,
    HttpClientModule,
    MatCardModule,
    MatDividerModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatToolbarModule,
    RouterModule,
    RouterOutlet,
  ],
  providers: [
    StoreService,
    AuthService,
    HttpService,
    AvatarService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true,
    },
    ProfileComponent,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
