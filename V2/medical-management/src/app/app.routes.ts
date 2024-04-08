import { Routes } from '@angular/router';
import { PatientMangementComponent } from './components/patient-mangement/patient-mangement.component';

export const routes: Routes = [
  {
    path: `patientmanagement`,
    component: PatientMangementComponent,
    title: 'Patient Management',
  },
];
