import { Component, OnInit } from '@angular/core';
import { Auth } from 'src/app/services/auth';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {

  constructor(private changeUser: Auth) { }

  ngOnInit() {
    this.changeUser.hiddenchangeUserLogin = true;
  }

}
