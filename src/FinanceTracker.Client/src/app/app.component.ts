import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { OnInit } from '@angular/core';
import { LogService } from './services/log.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
    // , HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})  
export class AppComponent implements OnInit {
  constructor (private logService: LogService) {}
  title = 'FinanceTracker';
  ngOnInit() {

  }
}
