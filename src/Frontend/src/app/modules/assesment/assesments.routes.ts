import { Routes } from '@angular/router';

export const assesmentRoutes: Routes = [
    {
        path: 'assesments',
        loadChildren: () =>
            import('./assesments/assesment.module').then(
                (m) => m.AssesmentsModule
            ),
    },
];
