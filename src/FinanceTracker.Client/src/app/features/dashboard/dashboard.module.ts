import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// Import the routing module
import { DashboardRoutingModule } from './dashboard-routing.module';

// Import your components
import { DashboardPageComponent } from './containers/dashboard-page/dashboard-page.component';
import { CategoryCardComponent } from './components/category-card/category-card.component';

@NgModule({
  imports: [
    CategoryCardComponent,
    CommonModule,
    DashboardRoutingModule,  // Import the routing module here
    DashboardPageComponent
  ]
})
export class DashboardModule { }
