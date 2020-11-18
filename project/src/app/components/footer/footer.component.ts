import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Auth } from 'src/app/services/auth';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  constructor(private router: Router, private reset: Auth) { }

  ngOnInit() {
  }
  
  home() {
    this.reset.resetLocalStorage = 0;
    this.router.navigate(['/log-in/']);
  }
}
