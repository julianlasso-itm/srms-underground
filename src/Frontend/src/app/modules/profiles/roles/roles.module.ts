import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { provideRouter } from '@angular/router';
import { rolesRoutes } from './roles.routes';

@NgModule({
    declarations: [],
    imports: [CommonModule],
    providers: [provideRouter(rolesRoutes)],
})
export class RolesModule {}
