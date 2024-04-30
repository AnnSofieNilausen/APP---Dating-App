import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserProfile } from '../models/user-profile'; // Adjust the path as necessary

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private apiUrl = 'http://your-api-url.com/api/users'; // Base URL for user-related API endpoints

  constructor(private http: HttpClient) { }

  // Fetches the profile of a user by their ID
  getProfile(userId: number): Observable<UserProfile> {
    // Constructs the URL to access the user's profile and makes an HTTP GET request
    return this.http.get<UserProfile>(`${this.apiUrl}/${userId}`);
  }

  // Updates the user's profile with new data
  updateProfile(profile: UserProfile): Observable<UserProfile> {
    // Makes an HTTP PUT request to update the user's profile on the server
    // Assumes the backend expects a user ID as part of the URL
    return this.http.put<UserProfile>(`${this.apiUrl}/${profile.pid}`, profile);
  }
}
