import { Component, OnInit } from '@angular/core';
import { Driver } from 'src/app/entities/driver';
import { User } from 'src/app/entities/user';
import { Router } from '@angular/router';
import { DriverServiceService } from 'src/app/services/driver-service.service';
import swal from 'sweetalert';

@Component({
  selector: 'app-edit-driver',
  templateUrl: './edit-driver.component.html',
  styleUrls: ['./edit-driver.component.scss']
})
export class EditDriverComponent implements OnInit {

  id: number;
  driver: Driver = new Driver(null, "", 0, "",  new User("", "", "", true, "", "", null, "", ""));
  drivers: Driver[] = [];

  constructor(private router: Router, private driverService: DriverServiceService) { }

  ngOnInit() {
    this.setUser();
  }

  setUser() {
    this.driver = JSON.parse(localStorage.getItem("driver"));
    this.driver.Name = JSON.parse(localStorage.getItem("user")).Name;
    this.driver.Gender = JSON.parse(localStorage.getItem("user")).Gender;
    this.driver.Mail = JSON.parse(localStorage.getItem("user")).Mail;
  }

  editDriver() {
    localStorage.setItem("driver", JSON.stringify(this.driver));
    this.driverService.updateDriver(this.driver).subscribe();

    swal({
      title: "הפרטים עודכנו במערכת",
      icon: "success"
    });
    this.router.navigate(['/exists-driver']);
  }

}
