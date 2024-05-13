import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Profile } from '../models/profile';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private apiUrl = 'https://localhost:7196/api/authentication';

  constructor(private http: HttpClient) {}

  // Login method to authenticate users.
  login(username: string, password: string): Observable<Profile> {
    const headers = new HttpHeaders({
      'Authorization': 'Basic ' + btoa(username + ':' + password)
    });

    return this.http.get<Profile>(`${this.apiUrl}/login?username=${username}&password=${password}`, { headers })
      .pipe(
        tap((profile: Profile) => {
          if (profile && profile.pid) {
            sessionStorage.setItem('userId', profile.pid.toString());
          }
        })
      );
  }

  // Re-authenticate the user for critical actions.
  reAuthenticate(username: string, password: string): Observable<boolean> {
    const headers = new HttpHeaders({
      'Authorization': 'Basic ' + btoa(username + ':' + password)
    });
    // Sending GET request with basic authentication headers and query parameters
    return this.http.get<boolean>(`${this.apiUrl}/reAuthenticate?username=${username}&password=${password}`, { headers })
      .pipe(
        tap(success => {
          console.log('Re-authentication ' + (success ? 'successful' : 'failed'));
        })
      );
  }

  // Get the current user's ID from session storage.
  getCurrentUserId(): number | null {
    const userId = sessionStorage.getItem('userId');
    return userId ? parseInt(userId) : null;
  }

  // Check if the user is logged in.
  isLoggedIn(): boolean {
    return this.getCurrentUserId() != null;
  }
}
