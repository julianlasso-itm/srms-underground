import { Routes } from '@angular/router';

export const profilesRoutes: Routes = [
  {
    path: 'skills',
    loadChildren: () =>
      import('./skills/skills.module').then((m) => m.SkillsModule),
  },
];
