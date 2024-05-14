// src/app/services/profile.service.ts

import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
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
    return this.http.put<Profile>(`${this.profileUrl}/`, profile);
  }

  deleteProfile(userId: number, username: string, password: string): Observable<any> {
    const params = new HttpParams()
      .set('userId', userId)
      .set('username', username)
      .set('password', password);
    return this.http.delete(`${this.profileUrl}`, { params });
}
}
