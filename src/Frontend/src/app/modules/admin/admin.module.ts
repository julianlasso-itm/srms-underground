import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { provideRouter } from '@angular/router';
import { adminRoutes } from './admin.routes';

@NgModule({
    declarations: [],
    imports: [CommonModule],
    providers: [provideRouter(adminRoutes)],
})
export class AdminModule {}
