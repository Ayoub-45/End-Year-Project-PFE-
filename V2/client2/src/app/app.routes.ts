import { Routes } from '@angular/router';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { AboutComponent } from './components/about/about.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
export const routes: Routes = [
  {
    path: '',
    component: AboutComponent,
    title: 'About Page',
  },
  {
    path: 'sign-in',
    component: SignInComponent,
    title: 'Sign-In Page',
  },
  {
    path: 'sign-in/sign-up',
    component: SignUpComponent,
    title: 'Sign-Up Page',
  },
];
