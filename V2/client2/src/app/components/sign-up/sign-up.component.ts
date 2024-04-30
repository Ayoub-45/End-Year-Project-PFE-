import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LogoComponent } from '../../reusable-components/logo/logo.component';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [NgIf,LogoComponent],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.css',
})
export class SignUpComponent implements OnInit {
  registrationForm!: FormGroup;
  constructor(private fb: FormBuilder) {}
  ngOnInit(): void {
    this.registrationForm = this.fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required, Validators.minLength(6)],
      confirmPassword: [
        '',
        [Validators.required, this.matchPasswordValidator.bind(this)],
      ],
    });
  }
  matchPasswordValidator(control: FormGroup): { [s: string]: boolean } | null {
    if (control.value !== this.registrationForm.get('password')?.value) {
      return { passwordDontMatch: true };
    }
    return null;
  }
}
