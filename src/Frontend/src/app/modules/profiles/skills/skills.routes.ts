import { Routes } from '@angular/router';

export const skillsRoutes: Routes = [
    {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full',
    },
    {
        path: 'list',
        loadComponent: () =>
            import('./skill/skill.component').then((m) => m.SkillComponent),
    },
    {
        path: ':id',
        loadComponent: () =>
            import('./skill-detail/skill-detail.component').then((m) => m.SkillDetailComponent),
    },
];
