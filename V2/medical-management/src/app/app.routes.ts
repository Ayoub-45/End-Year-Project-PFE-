import { Routes } from '@angular/router';
import { PatientMangementComponent } from './components/patient-mangement/patient-mangement.component';
import { AppComponent } from './app.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { HomeComponent } from './components/home/home.component';

export const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
  },

  {
    path: `signin`,
    component: SignInComponent,
  },
  {
    path: `patientmanagement`,
    component: PatientMangementComponent,
  },
];
