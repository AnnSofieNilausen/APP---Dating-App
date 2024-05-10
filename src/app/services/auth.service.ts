import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Profile } from '../models/profile';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private apiUrl = 'http://yourapi.com/api/authentication';

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<Profile> {
    // Create HTTP parameters
    let params = new HttpParams();
    params = params.append('username', username);
    params = params.append('password', password);

    // Send a GET request with parameters
    return this.http.get<Profile>(`${this.apiUrl}/login`, { params });
  }
}
