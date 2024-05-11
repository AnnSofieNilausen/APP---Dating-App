import { Component } from '@angular/core';
import { AuthenticationService } from '../../services/auth.service';
import { Router, NavigationExtras } from '@angular/router';
import { FormsModule } from '@angular/forms';


@Component({
 selector: 'app-login',
 standalone: true,
 templateUrl: './login.component.html',
 styleUrls: ['./login.component.css'],
 imports: [FormsModule]
})
export class LoginComponent {
 username: string = '';
 password: string = '';
 errorMessage: string = '';


 constructor(private authService: AuthenticationService, private router: Router) {}


 onLogin(): void {
   this.authService.login(this.username, this.password).subscribe({
     next: (profile) => {
       // Pass data directly via state
       const navigationExtras: NavigationExtras = {
         state: { profile }
       };
       this.router.navigate(['/profile'], navigationExtras);
     },
     error: (error) => {
       this.errorMessage = 'Invalid username or password';
     }
   });
 }
}
