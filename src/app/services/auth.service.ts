// auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5057/api/authentication'; // Base API URL

  constructor(private http: HttpClient, private router: Router) {}

  // Attempts to log the user in with provided credentials
  login(username: string, password: string): Observable<boolean> {
    const loginPayload = { username, password };
    return this.http.post<any>(`${this.apiUrl}/login`, loginPayload).pipe(
      tap(res => {
        // Redirect to the profile page after successful login
        this.router.navigate(['/profile']);
        return true;
      }),
      catchError(error => {
        // Log the error and throw a user-friendly message
        console.error('Login error:', error);
        return throwError(() => new Error('Login failed, please try again.'));
      })
    );
  }

  // Logs the user out
  logout(): void {
    // Navigate to the login page after logout
    this.router.navigate(['/login']);
  }
}
