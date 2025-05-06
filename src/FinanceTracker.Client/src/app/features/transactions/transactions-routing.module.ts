import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TransactionsPageComponent } from './containers/transactions-page/transactions-page.component';

// Define routes for the transactions feature
const routes: Routes = [
  {
    path: '', // This will be accessed at /transactions due to the parent route
    component: TransactionsPageComponent
  },
  // You can add additional routes here, for example:
  // {
  //   path: ':id', // For transaction details - would be accessed at /transactions/123
  //   component: TransactionDetailComponent
  // }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TransactionsRoutingModule { }
