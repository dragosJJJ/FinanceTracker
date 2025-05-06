import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TransactionsPageComponent } from './containers/transactions-page/transactions-page.component';

const routes: Routes = [
  {
    path: '',
    component: TransactionsPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TransactionsRoutingModule { }
