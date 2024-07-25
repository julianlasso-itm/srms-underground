export const menuStruct = [
  {
    title: 'Inicio',
    icon: 'home',
    path: '',
    children: [
      {
        title: 'Dashboard',
        path: 'dashboard',
        icon: 'dashboard',
        loadComponent: () =>
          import('./components/home/home.component').then(
            (component) => component.HomeComponent
          ),
      },
      {},
      {
        title: 'Clientes',
        path: 'customers',
        icon: 'people',
        loadComponent: () =>
          import('./modules/profiles/customers/customers.component').then(
            (component) => component.CustomersComponent
          ),
      },
      {
        title: 'Equipos',
        path: 'squads',
        icon: 'group',
        loadComponent: () =>
          import('./modules/profiles/squads/squads.component').then(
            (component) => component.SquadsComponent
          ),
      },
      {},
      {
        title: 'Profesionales',
        path: 'professionals',
        icon: 'people',
        loadComponent: () =>
          import(
            './modules/profiles/professionals/professionals.component'
          ).then((component) => component.ProfessionalsComponent),
      },
      {
        title: 'Habilidades',
        path: 'skills',
        icon: 'build',
        loadComponent: () =>
          import('./modules/profiles/skills/skills.component').then(
            (component) => component.SkillsComponent
          ),
      },
      {
        title: 'Roles',
        path: 'roles',
        icon: 'lock',
        loadComponent: () =>
          import('./modules/profiles/roles/roles.component').then(
            (component) => component.RolesComponent
          ),
      },
      {},
      {
        title: 'Preguntas',
        path: 'questions',
        icon: 'help',
        loadComponent: () =>
          import('./modules/query-bank/questions/questions.component').then(
            (component) => component.QuestionsComponent
          ),
      },
      {},
      {
        title: 'Evaluaciones',
        path: 'assessments',
        icon: 'assignment',
        loadComponent: () =>
          import('./modules/assessments/assessments/assessments.component').then(
            (component) => component.AssessmentsComponent
          ),
      },
      {
        title: 'Resultados',
        path: 'results',
        icon: 'bar_chart',
        loadComponent: () =>
          import('./modules/assessments/results/results.component').then(
            (component) => component.ResultsComponent
          ),
      },
      {
        title: 'Cierre de brechas',
        path: 'gap-closure',
        icon: 'build',
        loadComponent: () =>
          import('./modules/assessments/gap-closure/gap-closure.component').then(
            (component) => component.GapClosureComponent
          ),
      },
    ],
  },
  // {
  //   title: 'Reportes',
  //   icon: 'description',
  //   path: 'reports',
  //   children: [
  //     {
  //     },
  //   ],
  // },
  {
    title: 'Configuración del sistema',
    icon: 'settings',
    path: 'settings',
    children: [
      {
        title: 'Usuarios',
        path: 'users',
        icon: 'people',
        loadComponent: () =>
          import('./modules/security/users/users.component').then(
            (component) => component.UsersComponent
          ),
      },
      {
        title: 'Roles',
        path: 'roles',
        icon: 'lock',
        loadComponent: () =>
          import('./modules/security/roles/roles.component').then(
            (component) => component.RolesComponent
          ),
      },
    ],
  },
];
