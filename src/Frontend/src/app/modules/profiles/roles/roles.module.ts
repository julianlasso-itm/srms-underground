import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { provideRouter } from '@angular/router';
import { rolesRoutes } from './roles.routes';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [provideRouter(rolesRoutes)],
})
export class RolesModule {}
