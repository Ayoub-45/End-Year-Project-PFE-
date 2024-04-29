import { Component } from '@angular/core';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { LoadingScreenComponent } from './reusable-components/loading-screen/loading-screen.component';
import { AboutComponent } from './components/about/about.component';
import { RouterModule } from '@angular/router';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    SignInComponent,
    LoadingScreenComponent,
    RouterModule,
    AboutComponent,
    NgIf,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Medcal clinics';
  constructor() {}
}
