// profile.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserProfile } from '../models/profile'; 
import { ReactiveFormsModule } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private apiUrl = 'http://localhost:5057/api'; // Base URL for user-related API endpoints

  constructor(private http: HttpClient) { }

  // Fetches the profile of a user by their ID
  getProfile(userId: number): Observable<UserProfile> {
    return this.http.get<UserProfile>(`${this.apiUrl}/profileController/${userId}`);
  }

  // Updates the user's profile with new data
  updateProfile(profile: UserProfile): Observable<any> {
    return this.http.put(`${this.apiUrl}/profile/${profile.id}`, profile);
  }

  // Delete the user's profile 
  deleteProfile(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/profile/${id}`);
  }
}
