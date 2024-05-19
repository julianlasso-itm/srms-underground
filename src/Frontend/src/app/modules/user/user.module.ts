import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { provideRouter } from '@angular/router';
import { userRoutes } from './user.routes';

@NgModule({
    declarations: [],
    imports: [CommonModule],
    providers: [provideRouter(userRoutes)],
})
export class UserModule {}
