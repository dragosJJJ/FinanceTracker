import { Routes } from '@angular/router';
import { DashboardPageComponent } from './pages/dashboard-page/dashboard-page.component';
import { TransactionsPageComponent } from './pages/transactions-page/transactions-page.component';
import { CardComponent } from './components/card/card.component';
import { LayoutComponent } from './layout/layout.component';
import { WalletComponent } from './pages/wallet/wallet.component';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';



export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
 { 
   path: '',
    component: LayoutComponent, // Apply layout component as a wrapper
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      // { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
      { path: 'wallet', component: WalletComponent, canActivate: [AuthGuard] },
      { path: 'dashboard', component: DashboardPageComponent, canActivate: [AuthGuard] },
      { path: 'payment-methods', component: CardComponent, canActivate: [AuthGuard] },
      { path: 'transactions', component: TransactionsPageComponent, canActivate: [AuthGuard] },
    ]
  },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '**', redirectTo: 'login' },
];
