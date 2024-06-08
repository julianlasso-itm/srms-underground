import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { provideRouter } from '@angular/router';
import { squadsRoutes } from './squad.routes';

@NgModule({
    declarations: [],
    imports: [CommonModule],
    providers: [provideRouter(squadsRoutes)],
})
export class SquadsModule {}
