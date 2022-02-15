import { Component } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { VetrinaService } from './shared/vetrina.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  subscription: Subscription;
  intervalId: number;
  title = 'PasticceriaApp';

  ngOnInit() {
    // This is METHOD 1
    const source = interval(86400000);
    const text = 'Your Text Here';
    this.subscription = source.subscribe((val) => this.updatePrezzi()); 
  }

  ngOnDestroy() {
    // For method 1
    this.subscription && this.subscription.unsubscribe();
  }

  curDate = new Date();

  updatePrezzi () {
    

  }
  
}
