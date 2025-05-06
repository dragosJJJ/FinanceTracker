import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../../core/services/api.service';

interface Transaction {
  id: number;
  category: string;
  amount: string;
  location: string;
  date: string;
}

@Component({
  selector: 'app-transactions-page',
  templateUrl: './transactions-page.component.html',
  styleUrls: ['./transactions-page.component.scss']
})
export class TransactionsPageComponent implements OnInit {
  transactions: Transaction[] = [];
  isLoading = true;
  error: string | null = null;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    // For now, use mock data - later we'll connect to the API
    this.transactions = [
      { id: 1, category: 'Travel', amount: '15000$', location: 'Grece, Athens', date: '14mar2025' },
      { id: 2, category: 'Travel', amount: '12000$', location: 'USA', date: '12mar2025' },
      { id: 3, category: 'Travel', amount: '15000$', location: 'Grece, Athens', date: '14mar2025' }
    ];
    this.isLoading = false;

    // When ready to connect to API:
    // this.loadTransactions();
  }

  // Method to load transactions from API
  private loadTransactions(): void {
    this.isLoading = true;
    this.apiService.getTransactions().subscribe({
      next: (data) => {
        this.transactions = data;
        this.isLoading = false;
      },
      error: (err) => {
        this.error = 'Failed to load transactions';
        this.isLoading = false;
        console.error(err);
      }
    });
  }
}
