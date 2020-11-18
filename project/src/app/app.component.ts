import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  title = 'TravelInGroup';

  constructor() { }

  ngOnInit() {
  }
  closeApplication()
  {
    window.close();
  }

}
