import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Driver } from 'src/app/entities/driver';
import { DriverServiceService } from 'src/app/services/driver-service.service';
import { User } from 'src/app/entities/user';

@Component({
  selector: 'app-new-driver',
  templateUrl: './new-driver.component.html',
  styleUrls: ['./new-driver.component.scss']
})
export class NewDriverComponent implements OnInit {

  id: number;
  driver: Driver = new Driver(null, "", 0, "",  new User("", "", "", true,"","",null,"",""));
  drivers: Driver[] = [];

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private driverService: DriverServiceService) { }

  ngOnInit() {
    this.setUser();
  }

  setUser() {
    this.activatedRoute.url.subscribe(url => {
      this.id = +this.activatedRoute.snapshot.paramMap.get('id');
      this.driver.Identity = this.id.toString()
    });
  }

  saveDriver() {
    if (this.driver.NumberOfSeats != null && this.driver.NumberOfSeats != 0) {
      this.driverService.getDrivers().subscribe(state => { this.drivers = state });
      localStorage.setItem("driver", JSON.stringify(this.driver));
      
      console.log(this.driver);
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
  }

 
