import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Profile } from '../models/profile';
import { AuthenticationService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class MatchService {
  private matchFeedUrl = 'https://localhost:7196/api/MatchFeed';  // Base URL for match feed
  private matchUrl = 'https://localhost:7196/api/Match';  // Base URL for matches

  constructor(private http: HttpClient, private authService: AuthenticationService) {}

  getPotentialMatches(): Observable<Profile> {
    const userId = this.authService.getCurrentUserId();
    if (userId === null) {
      throw new Error("User not logged in");
    }
    return this.http.get<Profile>(`${this.matchFeedUrl}/GetProfile`, {
      params: new HttpParams().set('id', userId.toString())
    });
  }  

  getCurrentMatches(): Observable<Profile[]> {
    const userId = this.authService.getCurrentUserId();
    if (userId === null) {
      throw new Error("User not logged in");
    }
    return this.http.get<Profile[]>(`${this.matchUrl}/${userId}`);
  }

  likeProfile(likedUserId: number): Observable<any> {
    const likerId = this.authService.getCurrentUserId();
    if (likerId === null) {
      throw new Error("User not logged in");
    }
    return this.http.put(`${this.matchFeedUrl}/Like`, null, {
      params: new HttpParams().set('liker', likerId.toString()).set('liked', likedUserId.toString())
    });
  }

  dislikeProfile(dislikedUserId: number): Observable<any> {
    const dislikerId = this.authService.getCurrentUserId();
    if (dislikerId === null) {
      throw new Error("User not logged in");
    }
    return this.http.put(`${this.matchFeedUrl}/Dislike`, null, {
      params: new HttpParams().set('disliker', dislikerId.toString()).set('disliked', dislikedUserId.toString())
    });
  }
}
