import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { CardModel } from '../models/CardModels';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class CardsService {
  private baseUrl = 'https://localhost:7283/api/Card';

  constructor(private http: HttpClient, private authService: AuthService) {}

  getCards(): Observable<CardModel[]> {
    const token = this.authService.getToken();

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });

    return this.http
      .get<CardModel[]>(`${this.baseUrl}/user/1`, { headers })
      .pipe(
        map((cards) => {
          const sorted = cards
            .slice()
            .sort((a, b) => parseFloat(b.amount) - parseFloat(a.amount));

          return sorted.map((card, index) => ({
            ...card,
            priority: index + 1,
          }));
        })
      );
  }

  addCard(card: Partial<CardModel>): Observable<CardModel> {
    const token = this.authService.getToken();

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json',
    });

    return this.http.post<CardModel>(`${this.baseUrl}?userId=1`, card, {
      headers,
    });
  }
  deleteCardById(cardId: number): Observable<void> {
    const token = this.authService.getToken();

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });

    return this.http.delete<void>(`${this.baseUrl}/${cardId}`, { headers });
  }

  updateCard(card: CardModel): Observable<void> {
    const token = this.authService.getToken();

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json',
    });

    return this.http.put<void>(`${this.baseUrl}/${card.id}`, card, { headers });
  }
}
