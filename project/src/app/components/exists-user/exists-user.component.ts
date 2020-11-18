import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserServiceService } from 'src/app/services/user-service.service';
import { User } from 'src/app/entities/user';
import { DriverServiceService } from 'src/app/services/driver-service.service';
import { Driver } from 'src/app/entities/driver';
import { PassengerServiceService } from 'src/app/services/passenger-service.service';
import { Passenger } from 'src/app/entities/passenger';
import { Auth } from 'src/app/services/auth';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';

@Component({
  selector: 'app-exists-user',
  templateUrl: './exists-user.component.html',
  styleUrls: ['./exists-user.component.scss']
})
export class ExistsUserComponent implements OnInit {

  id: number;
  user: User = new User("", "", "", true,"","",null,"","");
  driver: Driver = new Driver(null, "", 0, "", new User("", "", "", true,"","",null,"",""));
  passenger: Passenger = new Passenger(null, "", new User("", "", "", true,"","",null,"",""));

  constructor(
    private spinnerService: Ng4LoadingSpinnerService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private userServiceService: UserServiceService,
    private driverService: DriverServiceService,
    private passengerService: PassengerServiceService,
    private changeUser: Auth
  ) { }

  ngOnInit() {
    this.changeUser.hiddenchangeUserLogin = true;
    this.setUser();
  }

  setUser() {
this.spinnerService.show();
    this.activatedRoute.url.subscribe(url => {
      this.id = +this.activatedRoute.snapshot.paramMap.get('id')
    });
    this.userServiceService.getUserById(this.id.toString()).subscribe((state: User) => {
      this.user = state;
      localStorage.setItem("user", JSON.stringify(this.user))
      this.passenger.Identity = state.Identity;
      this.spinnerService.hide();
    });
  }

  PassengerLogin() {

    this.changeUser.changeUserLogin = 2;
    this.changeUser.textUser = "החלף לנהג";
    this.passengerService.getPassengerById(this.user.Identity).subscribe((state: Passenger) => {
      state == null ?
        [this.passengerService.addPassenger(this.passenger).subscribe(p =>

          this.router.navigate(['/exists-passenger/' + parseInt(this.user.Identity)]))]
        :
        this.router.navigate(['/exists-passenger/' + parseInt(this.user.Identity)])
    });

  }

  DriverLogin() {
    this.driverService.getDriverById(this.user.Identity)
      .subscribe((state: Driver) => {
        state == null ?
          [this.router.navigate(['/new-driver/' + this.user.Identity])] :
          [localStorage.setItem("driver", JSON.stringify(state)), this.router.navigate(['/exists-driver'])]
      });
  }
}
