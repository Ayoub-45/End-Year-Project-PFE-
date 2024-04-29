import { Routes } from '@angular/router';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { AboutComponent } from './components/about/about.component';
export const routes: Routes = [
  {
    path: '',
    component: AboutComponent,
    title: 'About Page',
  },
  {
    path: 'sign-in',
    component: SignInComponent,
    title: 'sign in Page',
  },
];
