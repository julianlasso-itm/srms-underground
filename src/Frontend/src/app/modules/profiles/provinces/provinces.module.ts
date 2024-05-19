import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provincesRoutes } from './provinces.routes';

@NgModule({
    declarations: [],
    imports: [CommonModule],
    providers: [provideRouter(provincesRoutes)],
})
export class ProvincesModule {}
