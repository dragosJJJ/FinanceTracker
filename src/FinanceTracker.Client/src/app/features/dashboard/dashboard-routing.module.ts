import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardPageComponent } from './containers/dashboard-page/dashboard-page.component';

// Define routes for the dashboard feature
const routes: Routes = [
  {
    path: '', // This will be accessed at the root path due to the parent route
    component: DashboardPageComponent
  },
  // You can add additional dashboard-related routes here, for example:
  // {
  //   path: 'analysis',
  //   component: AnalysisComponent
  // }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
