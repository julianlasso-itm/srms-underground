import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { provideRouter } from '@angular/router';
import { assesmentRoutes } from './assesments.routes';

@NgModule({
    declarations: [],
    imports: [CommonModule],
    providers: [provideRouter(assesmentRoutes)],
})
export class AssesmentsModule {}
