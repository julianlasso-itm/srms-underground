import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { provideRouter } from '@angular/router';
import { securityRoutes } from './security.routes';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [provideRouter(securityRoutes)],
})
export class SecurityModule {}
