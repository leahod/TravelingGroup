import { Component, OnInit } from '@angular/core';
import { travelingDriver } from 'src/app/entities/travelingDriver';
import { TravelingServiceService } from 'src/app/services/traveling-service.service';
import { DriverServiceService } from 'src/app/services/driver-service.service';
import { travelingPassenger } from 'src/app/entities/travelingPassenger';
import { Router, ActivatedRoute } from '@angular/router';
import { UserServiceService } from 'src/app/services/user-service.service';
import { PassengerServiceService } from 'src/app/services/passenger-service.service';
import swal from 'sweetalert';
import { DatePipe } from '@angular/common';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';

@Component({
  selector: 'app-suitable-drivers',
  templateUrl: './suitable-drivers.component.html',
  styleUrls: ['./suitable-drivers.component.scss'],
  providers: [DatePipe]
})
export class SuitableDriversComponent implements OnInit {

  private a:any;
  travelingsDrivers: travelingDriver[] = [];
  travelingPassenger: travelingPassenger;
  identity: any;
  idTravelingPassenger: number;

  constructor
    (
    
      private spinnerService: Ng4LoadingSpinnerService,
      private router: Router,
      private activatedRoute: ActivatedRoute,
      private servicetravelingsD: TravelingServiceService
    ) { }

  ngOnInit() {
    this.spinnerService.show();
    this.getDriversSuitable();
  }
  getDays(numDays:string) 
  {
   var days  ="";
   if(numDays.includes("1"))
     days =`${days}ראשון, `
     if(numDays.includes("2"))
     days =`${days}שני, `
     if(numDays.includes("3"))
     days =`${days}שלישי, `
     if(numDays.includes("4"))
     days =`${days}רביעי, `
     if(numDays.includes("5"))
     days =`${days}חמישי, `
     if(numDays.includes("6"))
     days =`${days}שישי, `
     if(numDays.includes("7"))
     days =`${days}מוצ"ש, `
  
     return days;
     
  }
stop()
{
  this.spinnerService.hide();
}

  getDriversSuitable() {
   
    this.activatedRoute.url.subscribe(url => {
      this.idTravelingPassenger = +this.activatedRoute.snapshot.paramMap.get('id')
    });
    console.log(this.idTravelingPassenger);
    console.log(this.a);
    this.servicetravelingsD.getDriversSuitable(this.idTravelingPassenger)
      .subscribe((state: travelingDriver[]) => {
        console.log(state); this.travelingsDrivers = state;
        setTimeout(() => {
          this.spinnerService.hide()
        }, 6000);
      })
  }

  joinTraveling(e, idTravelingDriver: number) {
    if (e.target.checked) {
      this.spinnerService.show();
      this.servicetravelingsD.sendMail(idTravelingDriver, this.idTravelingPassenger).subscribe(x => {
        this.spinnerService.hide(),
          swal({
            title: "! בקשת הצטרפות התקבלה בהצלחה ",
            text: "נשלחה הודעת מייל לנהג",
            icon: "success"
          })
      })
    }
  }

  ok() {
    console.log(this.identity);
  }
}
