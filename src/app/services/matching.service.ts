import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PotentialMatch } from '../model/potential-match';

@Injectable({
  providedIn: 'root'
})
export class MatchingService {
  private apiUrl = 'http://localhost:5057/api/matches'; // replace with our API URL

  constructor(private http: HttpClient) {}

  // Get potential matches for the user
  getPotentialMatches(): Observable<PotentialMatch[]> {
    return this.http.get<PotentialMatch[]>(`${this.apiUrl}/potential`);
  }

  // Like a profile
  likeProfile(userId: number, likedUserId: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/like`, { userId, likedUserId });
  }

  // Dislike a profile
  dislikeProfile(userId: number, dislikedUserId: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/dislike`, { userId, dislikedUserId });
  }
}
