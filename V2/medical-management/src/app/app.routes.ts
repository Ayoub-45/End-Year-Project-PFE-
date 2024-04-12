import { Routes } from '@angular/router';
import { PatientMangementComponent } from './components/patient-mangement/patient-mangement.component';
import { AppComponent } from './app.component';
import { SignInComponent } from './components/sign-in/sign-in.component';

export const routes: Routes = [
  {
    path: `signin`,
    component: SignInComponent,
  },
  {
    path: `patientmanagement`,
    component: PatientMangementComponent,
  },
];
