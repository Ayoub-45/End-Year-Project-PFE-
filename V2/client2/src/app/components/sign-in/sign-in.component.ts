import { Component } from '@angular/core';
import { LogoComponent } from '../../reusable-components/logo/logo.component';
import { LoadingScreenComponent } from '../../reusable-components/loading-screen/loading-screen.component';
import { NgIf } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TIME_LOADING } from '../../constants';
@Component({
  selector: 'app-sign-in',
  standalone: true,
  imports: [LogoComponent, LoadingScreenComponent, NgIf, RouterModule],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.css',
})
export class SignInComponent {
  isLoading!: boolean;
  constructor() {
    this.isLoading = true;
    setTimeout(() => {
      this.isLoading = false;
    }, TIME_LOADING);
  }
}
