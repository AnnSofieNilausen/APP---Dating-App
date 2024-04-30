import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MutualMatch } from '../model/mutual-match';

@Injectable({
  providedIn: 'root'
})
export class MatchesService {
  private apiUrl = 'http://localhost:5057/api/matches'; // Replace with our API URL

  constructor(private http: HttpClient) {}

  // Get a list of mutual matches for the user
  getMutualMatches(userId: number): Observable<MutualMatch[]> {
    return this.http.get<MutualMatch[]>(`${this.apiUrl}/mutual/${userId}`);
  }

  // Delete a mutual match
  deleteMatch(userId: number, matchId: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${userId}/matches/${matchId}`);
  }
}
