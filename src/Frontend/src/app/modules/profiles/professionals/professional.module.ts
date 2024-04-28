import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { provideRouter } from '@angular/router';
import { professionalsRoutes } from './professional.routes';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [provideRouter(professionalsRoutes)],
})
export class ProfessionalsModule {}
