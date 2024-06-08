import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { provideRouter } from '@angular/router';
import { startRoutes } from './start.routes';

@NgModule({
    declarations: [],
    imports: [CommonModule, HttpClientModule],
    providers: [provideRouter(startRoutes)],
})
export class StartModule {}