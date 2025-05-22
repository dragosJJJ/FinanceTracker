import { Routes } from '@angular/router';
import { DashboardPageComponent } from './pages/dashboard-page/dashboard-page.component';
import { TransactionsPageComponent } from './pages/transactions-page/transactions-page.component';
import { CardComponent } from './components/card/card.component';
import { LayoutComponent } from './layout/layout.component';
import { WalletComponent } from './pages/wallet/wallet.component';


export const routes: Routes = [

 { 
   path: '',
    component: LayoutComponent, // Apply layout component as a wrapper
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      // { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
      { path: 'wallet', component: WalletComponent },
      { path: 'dashboard', component: DashboardPageComponent },
      { path: 'payment-methods', component: CardComponent },
      { path: 'transactions', component: TransactionsPageComponent },
    ]
  },
];
