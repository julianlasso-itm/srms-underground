import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { provideRouter } from '@angular/router';
import { assesmentsRoutes } from './assesment.routes';

@NgModule({
    declarations: [],
    imports: [CommonModule],
    providers: [provideRouter(assesmentsRoutes)],
})
export class AssesmentsModule {}
