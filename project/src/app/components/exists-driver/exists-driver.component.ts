import { Component, OnInit, ViewChild } from '@angular/core';
import { convertJsToTs, convertJsToTsSync } from 'js-to-ts-converter';
import { Router } from '@angular/router';
import { Driver } from 'src/app/entities/driver';
import { User } from 'src/app/entities/user';
import { Auth } from 'src/app/services/auth';

console.log('Done!');
@Component({
  selector: 'app-exists-driver',
  templateUrl: './exists-driver.component.html',
  styleUrls: ['./exists-driver.component.scss']
})
export class ExistsDriverComponent implements OnInit {

  driver: Driver = new Driver(null, "", 0, "",  new User("", "", "", true, "", "", null, "", ""));
  step = 0;

  constructor(private router: Router, private changeUser: Auth) { }

  ngOnInit() {
    this.changeUser.changeUserLogin = 1;
    this.changeUser.textUser = "החלף לנוסע";
    this.setDriver();
  }

  setDriver() {
    this.driver = JSON.parse(localStorage.getItem("driver"));
  }

  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }

  edit() {
    this.router.navigate(['/edit-user']);
  }

  addTravel() {
    this.router.navigate(['/new-traveling-d']);
  }

  getTravelings() {
    this.router.navigate(['/exists-traveling-d']);
  }
  getPayments() {
    this.router.navigate(['/paymentsD']);
  }
}
