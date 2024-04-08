import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { FormsModule, NgModel } from '@angular/forms';

export class AppModule {}
@Component({
  standalone: true,
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  imports: [FormsModule],
  styleUrls: ['./sign-in.component.css'],
})
export class SignInComponent implements OnInit {
  username: string = '';
  password: string = '';

  constructor(private router: Router) {}

  ngOnInit(): void {}

  onSubmit() {
    // Simulate authentication (replace with your logic)
    if (this.username === 'user' && this.password === 'password') {
      this.router.navigate(['/home']); // Assuming 'home' is your protected route
    } else {
      // Handle login failure (display error message)
    }
  }
}
