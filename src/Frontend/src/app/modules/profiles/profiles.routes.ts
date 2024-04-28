import { Routes } from '@angular/router';

export const profilesRoutes: Routes = [
  {
    path: 'skills',
    loadChildren: () =>
      import('./skills/skills.module').then((m) => m.SkillsModule),
  },

  {
    path: 'professionals',
    loadChildren: () =>
      import('./professionals/professional.module').then((m) => m.ProfessionalsModule),
  },
];
