import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/entities/user';
import { ActivatedRoute, Router } from '@angular/router';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { UserServiceService } from 'src/app/services/user-service.service';
import swal from 'sweetalert';

@Component({
  selector: 'app-edit-card-details',
  templateUrl: './edit-card-details.component.html',
  styleUrls: ['./edit-card-details.component.scss']
})
export class EditCardDetailsComponent implements OnInit {


  startDate = new Date(Date.now());
  endDate = null;
  numCard = null;
  user: User = new User("", "", "", false, " ", "", null, " ", " ");

  constructor(
    private activatedRoute: ActivatedRoute,
    private spinnerService: Ng4LoadingSpinnerService,
    private router: Router,
    private userServiceService: UserServiceService,
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
      this.userServiceService.updateUser(this.user).subscribe(x => this.spinnerService.hide())
      if (JSON.parse(localStorage.getItem("driver")))
        this.router.navigate(['/edit-driver']);

      else {
        swal({
          title: "הפרטים עודכנו במערכת",
          icon: "success"
        });
        this.router.navigate(['/exists-user/' + parseInt(this.user.Identity)]);
      }
    }

    else {
      swal({
        title: "לא הוזנו כל הפרטים",
        icon: "error"
      });
    }
  }
}
