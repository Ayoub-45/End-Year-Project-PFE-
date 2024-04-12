import { Routes } from '@angular/router';
import { PatientMangementComponent } from './components/patient-mangement/patient-mangement.component';
import { AppComponent } from './app.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { HomeComponent } from './components/home/home.component';
import { AddPatientComponent } from './components/add-patient/add-patient.component';

export const routes: Routes = [
  {
    path: ``,
    component: SignInComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: `patient-management`,
    component: PatientMangementComponent,
  },
  {
    path: `patient-management/add-patient`,
    component: AddPatientComponent,
  },
];
