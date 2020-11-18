import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/entities/user';
import { Router } from '@angular/router';
import { UserServiceService } from 'src/app/services/user-service.service';
import { Auth } from 'src/app/services/auth';
import swal from 'sweetalert';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';


@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})
export class LogInComponent implements OnInit {

  hide = true;
  user: User = new User("", "", "", true, "", "", null, "", "");
  identity: string;

  constructor(
    private spinnerService: Ng4LoadingSpinnerService,
    private router: Router,
    private userServiceService: UserServiceService,
    private reset: Auth
  ) { }

  ngOnInit() {

    this.reset.hiddenchangeUserLogin = false;

    if (this.reset.resetLocalStorage) {
      if (JSON.parse(localStorage.getItem("user")) != null)
        localStorage.removeItem("user");
      if (JSON.parse(localStorage.getItem("driver")) != null)
        localStorage.removeItem("driver");
      if (JSON.parse(localStorage.getItem("passenger")) != null)
        localStorage.removeItem("passenger");
    }

    const body = document.querySelector("body");
    const modal = document.querySelector(".modal");
    const modalButton = document.querySelector(".modal-button");
    const closeButton = document.querySelector(".close-button");
    const scrollDown = document.querySelector(".scroll-down");
    let isOpened = false;

    const openModal = () => {
      modal.classList.add("is-open");
      body.style.overflow = "hidden";
    };

    const closeModal = () => {
      modal.classList.remove("is-open");
      body.style.overflow = "initial";
    };

    window.addEventListener("scroll", () => {
      if (window.scrollY > window.innerHeight / 3 && !isOpened) {
        isOpened = true;
        scrollDown.setAttribute("style", "display:none");
        openModal();
      }
    });

    modalButton.addEventListener("click", openModal);
    closeButton.addEventListener("click", closeModal);

    document.onkeydown = evt => {
      evt.keyCode === 27 ? closeModal() : false;
    };
  }
  isIdIllegal(): boolean {
    var pattern = /^\d+$/;
    if (!pattern.test(this.identity) || !(this.identity.length == 9))
      return false;
    var sum: number = 0;
    for (var i = 0; i < 9; i++) {
      var k = ((i % 2) + 1) * (Number(this.identity[i]));
      if (k > 9)
        k -= 9;
      sum += k;
    }
    return sum % 10 == 0;
  }

  UserLogin() {
   
    if (!this.isIdIllegal()) {
      swal({
        title: " תעודת זהות שגויה",
        icon: "error"
      });
    }
    else {
      this.spinnerService.show();
      if (JSON.parse(localStorage.getItem("user")) != null)
        localStorage.removeItem("user");
      if (JSON.parse(localStorage.getItem("driver")) != null)
        localStorage.removeItem("driver");
      if (JSON.parse(localStorage.getItem("passenger")) != null)
        localStorage.removeItem("passenger");
      if (this.identity) {
        this.userServiceService.getUserById(this.identity).subscribe((state: User) => {
          this.spinnerService.hide();
          state.Name == null ?
            this.router.navigate(['/new-user/' + parseInt(this.identity)]) :
            this.router.navigate(['/exists-user/' + parseInt(this.identity)])
        });
      }
    }

  }
}
