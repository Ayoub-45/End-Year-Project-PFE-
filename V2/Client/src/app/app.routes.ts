import { Routes } from '@angular/router';
import { DefaultLayoutComponent } from './layout';
import { PatientComponent } from '../app/components/patient/patient.component';
import { AddPatientComponent } from '../app/components/add-patient/add-patient.component';
import { EditPatientComponent } from '../app/components/edit-patient/edit-patient.component';
import { DoctorComponent } from '../app/components/doctor/doctor.component';
import { PatientDashboardComponent } from '../app/components/patient-dashboard/patient-dashboard.component';
import { AddExamComponent } from '../app/components/add-exam/add-exam.component';
export const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },

  {
    path: '',
    component: DefaultLayoutComponent,
    data: {
      title: 'Home',
    },

    children: [
      {
        path: 'doctor',
        component: DoctorComponent,
        data: {
          title: 'Doctor managment',
        },
      },
      {
        path: 'patient',
        component: PatientComponent,
        data: {
          title: 'Patient managment',
        },
      },
      {
        path: 'add-patient',
        component: AddPatientComponent,
        data: {
          title: 'Add patient',
        },
      },
      {
        path: ':id/patient-dashboard',
        component: PatientDashboardComponent,
        data: {
          title: 'Patient Dashboard',
        },
      },
      {
        path: ':id/edit-patient',
        component: EditPatientComponent,
        data: {
          title: 'Edit patient',
        },
      },
      {
        path: ':idPatient/patient-dashboard/add-exam',
        component: AddExamComponent,
        data: {
          title: 'Add exam',
        },
      },

      {
        path: 'dashboard',
        loadChildren: () =>
          import('./views/dashboard/routes').then((m) => m.routes),
      },
      {
        path: 'theme',
        loadChildren: () =>
          import('./views/theme/routes').then((m) => m.routes),
      },
      {
        path: 'base',
        loadChildren: () => import('./views/base/routes').then((m) => m.routes),
      },
      {
        path: 'buttons',
        loadChildren: () =>
          import('./views/buttons/routes').then((m) => m.routes),
      },
      {
        path: 'forms',
        loadChildren: () =>
          import('./views/forms/routes').then((m) => m.routes),
      },
      {
        path: 'icons',
        loadChildren: () =>
          import('./views/icons/routes').then((m) => m.routes),
      },
      {
        path: 'notifications',
        loadChildren: () =>
          import('./views/notifications/routes').then((m) => m.routes),
      },
      {
        path: 'widgets',
        loadChildren: () =>
          import('./views/widgets/routes').then((m) => m.routes),
      },
      {
        path: 'charts',
        loadChildren: () =>
          import('./views/charts/routes').then((m) => m.routes),
      },
      {
        path: 'pages',
        loadChildren: () =>
          import('./views/pages/routes').then((m) => m.routes),
      },
    ],
  },
  {
    path: '404',
    loadComponent: () =>
      import('./views/pages/page404/page404.component').then(
        (m) => m.Page404Component
      ),
    data: {
      title: 'Page 404',
    },
  },
  {
    path: '500',
    loadComponent: () =>
      import('./views/pages/page500/page500.component').then(
        (m) => m.Page500Component
      ),
    data: {
      title: 'Page 500',
    },
  },
  {
    path: 'login',
    loadComponent: () =>
      import('./views/pages/login/login.component').then(
        (m) => m.LoginComponent
      ),
    data: {
      title: 'Login Page',
    },
  },
  {
    path: 'register',
    loadComponent: () =>
      import('./views/pages/register/register.component').then(
        (m) => m.RegisterComponent
      ),
    data: {
      title: 'Register Page',
    },
  },
  { path: '**', redirectTo: 'dashboard' },
];
