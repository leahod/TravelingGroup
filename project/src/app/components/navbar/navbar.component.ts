import { Component, OnInit } from '@angular/core';
import { Auth } from 'src/app/services/auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(private router: Router, private reset: Auth) { }

  ngOnInit() {
    $(document).ready(function () {
      $("#mobile_nav").click(function () {
        if ($("#primary_nav").css("left") < "0px") {
          $("#primary_nav").animate({ left: "0px" }, 200);
          $("#wrapper_main_content").animate({ left: "150px" }, 200);
          $("#wrapper_main_content").css("overflow-y", "hidden");
          $("body").css("overflow-x", "hidden");
          $("#primary_nav").css("overflow-y", "hidden");
        } else {
          $("#primary_nav").animate({ left: "-115px" }, 200);
          $("#wrapper_main_content").animate({ left: "0px" }, 200);
          $("#wrapper_main_content").css("overflow-y", "hidden");
          $("body").css("overflow-x", "hidden");
        }
      });
    });
  }

  home() {
    this.reset.resetLocalStorage = 0;
    this.router.navigate(['/log-in/']);
  }
}
