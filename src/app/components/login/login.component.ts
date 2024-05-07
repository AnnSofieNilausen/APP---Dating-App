import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
// login.component.ts
export class LoginComponent {
  username: string | undefined = ''; // Initialize with an empty string
  password: string | undefined = ''; // Initialize with an empty string
  loginError: string = ''; // Used to display error messages to the user
  router: any;

  constructor(private authService: AuthService) {}

  // Called when the user submits the login form
  onLogin(): void {
    // Check if username and password are not empty before calling login
    if (this.username && this.password) {
      this.authService.login(this.username, this.password).subscribe({
        next: () => {
          console.log('Login successful');
          // Navigate to the profile page upon successful login
          this.router.navigate(['/profile']);
        },
        error: (error) => {
          // Display an error message on login failure
          this.loginError = error.message;
          console.log('Login failed:', error.message);
        }
      });
    } 
    else {
      // Handle case where username or password is empty
      this.loginError = 'Username and password are required.';
    }
  }
}
