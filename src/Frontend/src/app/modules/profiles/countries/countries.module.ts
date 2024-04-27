import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { provideRouter } from '@angular/router';
import { countriesRoutes } from './countries.routes';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [provideRouter(countriesRoutes)],
})
export class CountriesModule {}
