import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { RegisterationService } from '../../services/registeration.service'
import { Registeration } from 'src/app/entities/registeration';
import { TravelingServiceService } from 'src/app/services/traveling-service.service';
import { travelingDriver } from 'src/app/entities/travelingDriver';
import swal from 'sweetalert';
import { SweetAlert } from 'sweetalert/typings/core';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
@Component({
  selector: 'app-confirm-passenger',
  templateUrl: './confirm-passenger.component.html',
  styleUrls: ['./confirm-passenger.component.scss']
})
export class ConfirmPassengerComponent implements OnInit {

  detaisTravelings: Params;
  registeration: Registeration = new Registeration(0, 0, 0);
  travelingDriver: travelingDriver = new travelingDriver(null, 0, "", "", null, null, null, 0, "", "", 0, 0, 0, 0, 0, 0, true);

  constructor(
    private registerationService: RegisterationService,
    private router: Router,
    private spinnerService: Ng4LoadingSpinnerService,
    private activatedRoute: ActivatedRoute,
    private servicetravelingsD: TravelingServiceService
  ) { }

  ngOnInit() {

    this.activatedRoute.queryParamMap
      .subscribe((params) => {
        this.detaisTravelings = { ...params.keys, ...params, ...params.keys, ...params }; console.log(this.detaisTravelings.params.id)
      }
      );
    this.registeration.travelingIdDriver = this.detaisTravelings.params.idTravelingD;
    this.registeration.travelingIdPassenger = this.detaisTravelings.params.idTravelingP;
    this.setTravelingD();

    swal("האם הנך מאשר הצטרפותך לנסיעה", {
      buttons: {

        catch: {
          text: "אישור",
          value: "catch",
        },
        catch1: {
          text: "ביטול",
          value: "catch1",
        },
      },
    })
      .then((value) => {
        switch (value) {
          case "catch":
            this.confirmTraveling();

            break;
          case "catch1":
            swal("ביטול הצטרפות נוסע", "האם אתה בטוח?", "error");
            this.close();
            break;
        }
      });
  }

  close() {
    setTimeout(() => {
      window.close()
    }, 5000);
  }

  setTravelingD() {
    this.servicetravelingsD.getTravelingDriver(this.registeration.travelingIdDriver).subscribe(
      (travelingD: travelingDriver) => {
        this.travelingDriver = travelingD
      })
  }
  confirmTraveling() {
   
    this.spinnerService.show();
    this.registerationService.addRegisteration(this.registeration).subscribe((x) => {
      this.spinnerService.hide(); swal("! צורפת לנסיעה בהצלחה", "נסיעה בטוחה", "success")
      this.close()

    }
    );
    // else

    // swal("מצטערים!", "הנסיעה בתפוסה מלאה", "error");


  }
}


