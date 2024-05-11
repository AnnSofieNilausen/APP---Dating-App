// src/app/services/profile.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Profile } from '../models/profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private profileUrl = 'https://localhost:7196/api/profile';  // Adjust URL as needed

  constructor(private http: HttpClient) {}

  getProfile(userId: number): Observable<Profile> {
    return this.http.get<Profile>(`${this.profileUrl}/${userId}`);
  }

  updateProfile(userId: number, profile: Profile): Observable<Profile> {
    return this.http.put<Profile>(`${this.profileUrl}/${userId}`, profile);
  }

  deleteProfile(userId: number): Observable<any> {
    return this.http.delete(`${this.profileUrl}/${userId}`);
  }
}
