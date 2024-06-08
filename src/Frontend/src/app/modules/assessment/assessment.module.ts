import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { provideRouter } from '@angular/router';
import { assessmentRoutes } from './assessment.routes';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [provideRouter(assessmentRoutes)],
})
export class AssessmentModule {}
