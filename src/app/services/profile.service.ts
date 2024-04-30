import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserProfile } from '../model/user-profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private apiUrl = 'http://localhost:5057/api/profiles'; // chaneg to our API URL

  constructor(private http: HttpClient) {}

  // Create a new user profile
  createProfile(profile: UserProfile): Observable<UserProfile> {
    return this.http.post<UserProfile>(this.apiUrl, profile);
  }

  // Get the user profile
  getProfile(id: number): Observable<UserProfile> {
    return this.http.get<UserProfile>(`${this.apiUrl}/${id}`);
  }

  // Update user profile
  updateProfile(profile: UserProfile): Observable<UserProfile> {
    return this.http.put<UserProfile>(`${this.apiUrl}/${profile.pid}`, profile);
  }

  // Delete user profile
  deleteProfile(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
