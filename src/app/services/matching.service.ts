import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MatchingService {
  private apiUrl = 'http://your-api-url.com/api/matching'; // Adjust as needed

  constructor(private http: HttpClient) { }

  // Fetches the next potential match
  getNextProfile(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/next`);
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
