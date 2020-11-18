import { Component, OnInit } from '@angular/core';
import { Driver } from 'src/app/entities/driver';
import { DriverServiceService } from 'src/app/services/driver-service.service';
import { User } from 'src/app/entities/user';
import { Router, ActivatedRoute } from '@angular/router';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { UserServiceService } from 'src/app/services/user-service.service';
import { Auth } from 'src/app/services/auth';
import swal from 'sweetalert';

@Component({
  selector: 'app-card-details',
  templateUrl: './card-details.component.html',
  styleUrls: ['./card-details.component.scss']
})
export class CardDetailsComponent implements OnInit {

  startDate = new Date(Date.now());
  endDate = null;
  numCard = null;
  user: User = new User("", "", "", false, "", " ", null, " ", " ");
  driver: Driver = new Driver(null, "", 0, "",   new User("", "", "", true, "", "", null, "", ""));

  constructor(
    private driverService: DriverServiceService,
    private activatedRoute: ActivatedRoute,
    private spinnerService: Ng4LoadingSpinnerService,
    private router: Router,
    private userServiceService: UserServiceService,
    private changeUser: Auth
  ) { }

  ngOnInit() {
    this.setUser();
  }
  setUser() {
    this.user = JSON.parse(localStorage.getItem("user"));

  }
  
  save() {
    this.spinnerService.show();
    if (this.user.CreditCardNumber != null && this.user.Cvv != null && this.user.Validity != null && this.user.IdCardOwner != null) {
      
      localStorage.setItem("user", JSON.stringify(this.user));
      this.userServiceService.addUser(this.user).subscribe(x => {
        this.spinnerService.hide();
        setTimeout(() => {
          this.router.navigate(['/exists-user/' + parseInt(this.user.Identity)])
        }, 2000);
      });
    }

    else {
      swal({
        title: "לא הוזנו כל הפרטים",
        icon: "error"
      });
    }
  }
}