import { Routes } from '@angular/router';
import { DashboardPageComponent } from '..//pages/dashboard-page/dashboard-page.component';
//import { LoginComponent } from './components/login/login.component';
//import { RegisterComponent } from './components/register/register.component';
//import { AuthGuard } from './guards/auth.guard';
import { WalletComponent } from '../pages/wallet/wallet.component';
import { TransactionsComponent } from '../pages/transactions/transactions.component';
import { CategoriesComponent } from '../pages/categories/categories.component';
// import { AuthGuard } from '../guards/auth.guard';

export const routes: Routes = [ 
  { path: 'dashboard', component: DashboardPageComponent },
    // , canActivate: [AuthGuard] },
  { path: 'wallet', component: WalletComponent },
  { path: 'transactions', component: TransactionsComponent },
  // { path: 'categories', component: CategoriesComponent },
];
