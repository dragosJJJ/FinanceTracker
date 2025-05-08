import { Routes } from '@angular/router';
import { DashboardPageComponent } from './features/dashboard/containers/dashboard-page/dashboard-page.component';
import { TransactionsPageComponent } from './features/transactions/containers/transactions-page/transactions-page.component';

export const routes: Routes = [
  {
    path: '', component: DashboardPageComponent
  },
  {
    path: 'transactions', component: TransactionsPageComponent
  },
  {
    path: '**',
    redirectTo: ''
  }
];
