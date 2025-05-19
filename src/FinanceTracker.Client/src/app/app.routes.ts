import { Routes } from '@angular/router';
import { DashboardPageComponent } from './features/pages/dashboard-page/dashboard-page.component';
import { TransactionsPageComponent } from './features/pages/transactions-page/transactions-page.component';
import { CardComponent } from './features/components/card/card.component';
import { LayoutComponent } from './features/layout/containers/layout/layout.component';


export const routes: Routes = [

 { 
   path: '',
    component: LayoutComponent, // Apply layout component as a wrapper
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      // { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
      { path: 'dashboard', component: DashboardPageComponent },
      { path: 'payment-methods', component: CardComponent },
      { path: 'transactions', component: TransactionsPageComponent },
    ]
  },
];
