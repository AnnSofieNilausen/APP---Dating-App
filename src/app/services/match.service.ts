// src/app/services/match.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Profile } from '../models/profile';

@Injectable({
  providedIn: 'root'
})
export class MatchService {
  private matchFeedUrl = 'http://yourapi.com/api/matchFeed';  // Adjust URL as needed
  private matchUrl = 'http://yourapi.com/api/match';          // Adjust URL as needed

  constructor(private http: HttpClient) {}

  getPotentialMatches(): Observable<Profile[]> {
    return this.http.get<Profile[]>(`${this.matchFeedUrl}/potential`);
  }

  getCurrentMatches(): Observable<Profile[]> {
    return this.http.get<Profile[]>(`${this.matchFeedUrl}/current`);
  }

  likeProfile(likedUserId: number): Observable<any> {
    return this.http.post(`${this.matchUrl}/like`, { likedUserId });
  }

  dislikeProfile(dislikedUserId: number): Observable<any> {
    return this.http.post(`${this.matchUrl}/dislike`, { dislikedUserId });
  }

  deleteMatch(matchId: number): Observable<any> {
    return this.http.delete(`${this.matchUrl}/delete/${matchId}`);
  }
}
