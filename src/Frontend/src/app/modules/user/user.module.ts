import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { userRoutes } from './user.routes';
import { provideRouter } from '@angular/router';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [provideRouter(userRoutes)],
})
export class UserModule {}
