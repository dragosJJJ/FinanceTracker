import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Transaction } from '../models/transaction.model';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  private mockTransactions: Transaction[] = [
    {
      id: 1,
      category: 'Travel',
      amount: 15000,
      location: 'Greece, Athens',
      date: new Date('2025-03-14')
    },
    {
      id: 2,
      category: 'Travel',
      amount: 12000,
      location: 'USA',
      date: new Date('2025-03-12')
    },
    {
      id: 3,
      category: 'Travel',
      amount: 15000,
      location: 'Greece, Athens',
      date: new Date('2025-03-14')
    }
  ];

  constructor(private http: HttpClient) { }

  getTransactions(): Observable<Transaction[]> {
    // return this.http.get<Transaction[]>('/api/transactions');
    return of(this.mockTransactions);
  }

  addTransaction(transaction: Transaction): Observable<Transaction> {
    // return this.http.post<Transaction>('/api/transactions', transaction);
    return of({...transaction, id: this.mockTransactions.length + 1});
  }
}
