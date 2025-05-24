import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { CategoryModel } from '../models/Category';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private baseUrl = 'https://localhost:7283/api/Categories';

  constructor(private http: HttpClient, private authService: AuthService) {}

  getCategories(): Observable<CategoryModel[]> {
    const token = this.authService.getToken();

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });

    return this.http.get<CategoryModel[]>(`${this.baseUrl}/user/1`, { headers });

  }

  addCategory(category: Partial<CategoryModel>): Observable<CategoryModel> {
    const token = this.authService.getToken();

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json',
    });

    return this.http.post<CategoryModel>(`${this.baseUrl}?userId=1`, category, {
      headers,
    });
  }
}
