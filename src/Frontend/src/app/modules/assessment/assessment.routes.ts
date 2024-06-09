import { Routes } from '@angular/router';

export const assessmentRoutes: Routes = [
  {
    path: 'assessments',
    loadComponent: () =>
      import('./assessments/assessments.component').then(
        (m) => m.AssessmentsComponent
      ),
  },
  {
    path: 'create',
    loadComponent: () =>
      import('./create-assessment/create-assessment.component').then(
        (m) => m.CreateAssessmentComponent
      ),
  },
  {
    path: 'go/:id',
    loadComponent: () =>
      import('../assesment/assesments/go-assessment/go-assessment.component').then(
        (m) => m.GoAssessmentComponent
      ),
  },
];
