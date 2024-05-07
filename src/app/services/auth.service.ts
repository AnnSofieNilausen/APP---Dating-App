import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loginUrl = 'http://localhost:5057/api/login'; // Adjust as needed for your API

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(this.loginUrl, { username, password }, { headers });
  }

  // Assuming token storage in local storage for simplicity
  saveToken(token: string): void {
    localStorage.setItem('userToken', token);
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('userToken');
  }

  logout(): void {
    localStorage.removeItem('userToken');
  }
}
