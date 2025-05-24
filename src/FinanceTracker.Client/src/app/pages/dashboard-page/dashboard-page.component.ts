import { Component } from '@angular/core';
import { CategoryCardComponent } from '../../components/category-card/category-card.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 

@Component({
  selector: 'app-dashboard-page',
  imports: [CategoryCardComponent, CommonModule, FormsModule],
  templateUrl: './dashboard-page.component.html',
  styleUrl: './dashboard-page.component.css',
})
export class DashboardPageComponent {  

  showAddForm = false;
    newCategory = { title: '', description: '' };


  onShowAddForm() {
    this.showAddForm = true;
  }
  onCancelAdd() {
    this.showAddForm = false;
    this.newCategory = { title: '', description: '' };
  }
    onAddCategory() {
  // if (!this.newCategory.title || !this.newCategory.description) return;
  // this.categoriesService.addCategory(this.newCategory).subscribe({
  //   next: (category) => {
  //     this.categories.push(category);
  //     this.notFound = false;
  //     this.newCategory = { title: '', description: '' };
  //     this.showAddForm = false;
  //   },
  // });
  }
}
