import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { provideRouter } from '@angular/router';
import { citiesRoutes } from './cities.routes';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [provideRouter(citiesRoutes)],
})
export class CitiesModule {}
