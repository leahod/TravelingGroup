import { Component, OnInit } from '@angular/core';
import { Driver } from 'src/app/entities/driver';
import { User } from 'src/app/entities/user';
import { DriverServiceService } from 'src/app/services/driver-service.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-bank-details',
  templateUrl: './bank-details.component.html',
  styleUrls: ['./bank-details.component.scss']
})
export class BankDetailsComponent implements OnInit {

  driver: Driver = new Driver(null, "", 0, "",  new User("", "", "", true,"","",null,"",""));
 
  constructor(
    private driverService: DriverServiceService,private router: Router, private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this.setDriver();
  }
  setDriver() {
  this.driver= JSON.parse(localStorage.getItem("driver"));
  this.driver.Identity=(JSON.parse(localStorage.getItem("user"))).Identity;
  this.driver.Gender=(JSON.parse(localStorage.getItem("user"))).Gender;
  this.driver.Name=(JSON.parse(localStorage.getItem("user"))).Name;
  this.driver.Mail=(JSON.parse(localStorage.getItem("user"))).Mail;
  console.log(this.driver);
  }
  save()
  {
    this.driverService.addDriver(this.driver).subscribe
    (x =>
      (
        this.driverService.getDriverById(this.driver.Identity).subscribe
          (
            (state: Driver) => {
              localStorage.setItem("driver", JSON.stringify(state)) ,
              this.router.navigate(['/exists-driver']) 
               
            }
          )
      )
    );
  }

}
