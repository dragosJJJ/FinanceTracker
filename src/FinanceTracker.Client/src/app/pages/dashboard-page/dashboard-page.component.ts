import { Component } from '@angular/core';
import { CategoryCardComponent } from '../../components/category-card/category-card.component';

@Component({
  selector: 'app-dashboard-page',
  imports: [CategoryCardComponent],
  templateUrl: './dashboard-page.component.html',
  styleUrl: './dashboard-page.component.css',
})
export class DashboardPageComponent {

}
