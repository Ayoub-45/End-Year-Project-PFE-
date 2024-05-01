import { Component } from '@angular/core';
import { LogoComponent } from '../../reusable-components/logo/logo.component';
import { LoadingScreenComponent } from '../../reusable-components/loading-screen/loading-screen.component';
import { NgIf } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TIME_LOADING } from '../../constants';
@Component({
  selector: 'app-sign-in',
  standalone: true,
  imports: [
    LogoComponent,
    LoadingScreenComponent,
    NgIf,
    RouterModule,
    ReactiveFormsModule,
  ],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.css',
})
export class SignInComponent {
  isLoading!: boolean;
  formGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });
  constructor() {
    this.isLoading = true;
    setTimeout(() => {
      this.isLoading = false;
    }, TIME_LOADING);
    console.log(TIME_LOADING);
  }
  onSubmit() {
    console.warn(this.formGroup.value);
  }
}
