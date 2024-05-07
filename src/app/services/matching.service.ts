import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class MatchingService {
  private apiUrl = 'http://your-api-url.com/api/matchfeed'; 

  constructor(private http: HttpClient) { }

  // Fetches a list of potential matches
  getProfiles(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/profiles`);
  }

  // Sends a 'like' for a specific profile ID
  likeProfile(profileId: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/like/${profileId}`, {});
  }

  // Sends a 'dislike' for a specific profile ID
  dislikeProfile(profileId: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/dislike/${profileId}`, {});
  }
}
