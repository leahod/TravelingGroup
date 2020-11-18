import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Passenger } from 'src/app/entities/passenger';
import { User } from 'src/app/entities/user';
import { PassengerServiceService } from 'src/app/services/passenger-service.service';

@Component({
  selector: 'app-exists-passenger',
  templateUrl: './exists-passenger.component.html',
  styleUrls: ['./exists-passenger.component.scss']
})
export class ExistsPassengerComponent implements OnInit {

  passenger: Passenger = new Passenger(null, "", new User("", "", "", true,"","",null,"",""));
  user: User = new User("", "", "", true,"","",null,"","");

  constructor(private router: Router, private passengerService: PassengerServiceService) { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem("user"));
    this.setPassenger();

  }

  setPassenger() {
    this.passengerService.getPassengerById(JSON.parse(localStorage.getItem("user")).Identity).subscribe((state: Passenger) => {
      localStorage.setItem("passenger", JSON.stringify(state))
    });
  }

  edit() {
    this.router.navigate(['/edit-user']);
  }

  addTravel() {
    this.router.navigate(['/new-traveling-p']);
  }

  getTravelings() {
    this.router.navigate(['/exists-traveling-p']);
  }

  getPayments()
  {
    this.router.navigate(['/paymentsP']);
  }
}
