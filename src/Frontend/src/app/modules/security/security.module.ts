import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { provideRouter } from '@angular/router';
import { securityRoutes } from './security.routes';

@NgModule({
    declarations: [],
    imports: [CommonModule, HttpClientModule],
    providers: [provideRouter(securityRoutes)],
})
export class SecurityModule {}
