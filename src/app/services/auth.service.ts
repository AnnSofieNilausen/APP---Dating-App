import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators'; // Import tap operator for side-effects
import { Profile } from '../models/profile';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private apiUrl = 'https://localhost:7196/api/authentication';

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<Profile> {
    let params = new HttpParams()
      .append('username', username)
      .append('password', password);

    // Assuming the backend returns the profile including an 'id' field upon successful login
    return this.http.get<Profile>(`${this.apiUrl}/login`, { params }).pipe(
      tap((profile: Profile) => {
        if (profile && profile.pid) {
          sessionStorage.setItem('userId', profile.pid.toString()); // Store user ID in session storage
        }
      })
    );
  }

  // Method to retrieve the current user's ID from session storage
  getCurrentUserId(): number | null {
    const userId = sessionStorage.getItem('userId');
    return userId ? parseInt(userId) : null;  // Changed from -1 to null
  }

  // Method to check if the user is logged in
  isLoggedIn(): boolean {
    return this.getCurrentUserId() != null;
  }

  // Logout method to clear the session
  logout(): void {
    sessionStorage.removeItem('userId'); // Clear user ID from session storage
  }
}
