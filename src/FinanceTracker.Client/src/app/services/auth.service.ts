import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'https://localhost:7283/api/Account';

  constructor(private http: HttpClient, private router: Router) {}

  login(data: { email: string; password: string }): Observable<any> {
  return this.http.post<any>(`${this.baseUrl}/login`, data).pipe(
    tap(response => {
      if (response.token && response.userId && response.name) {
        this.saveAuthData(response.token, response.userId, response.name);
      }
    })
  );
  }
 
  register(data: { username: string; email: string; password: string }): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/register`, data).pipe(
      tap(response => {
        if (response.token && response.userId && response.name) {
          this.saveAuthData(response.token, response.userId, response.name);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    localStorage.removeItem('name');
    this.router.navigate(['/login']); 
  }

  saveToken(token: string) {
    localStorage.setItem('token', token);
  }

  saveAuthData(token: string, userId: number, name: string) {
    localStorage.setItem('token', token);
    localStorage.setItem('userId', userId.toString());
    localStorage.setItem('name', name);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getUserId(): string | null {
    return localStorage.getItem('userId');
  }

  getUserName(): string | null {
    return localStorage.getItem('name');
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }
}
