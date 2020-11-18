import { Component, OnInit } from '@angular/core';
import { travelingPassenger } from 'src/app/entities/travelingPassenger';
import { Time } from '@angular/common';
import { TravelingPassengerService } from 'src/app/services/traveling-passenger.service';
import { Router } from '@angular/router';
import { Registeration } from 'src/app/entities/registeration';
import swal from 'sweetalert';
import { RegisterationService } from 'src/app/services/registeration.service';
import { Auth } from 'src/app/services/auth';
import { MatDialog } from '@angular/material/dialog';
import { DeleteTravelingRegPComponent } from '../delete-traveling-reg-p/delete-traveling-reg-p.component';
import { DeleteTravelingPComponent } from '../delete-traveling-p/delete-traveling-p.component'
import { ReportComponent } from '../report/report.component';

@Component({
  selector: 'app-exists-traveling-p',
  templateUrl: './exists-traveling-p.component.html',
  styleUrls: ['./exists-traveling-p.component.scss']
})
export class ExistsTravelingPComponent implements OnInit {

  openWithNot: number = 0;
  openWith: number = 0;
  arrowWithNot: string = "arrow_drop_down";
  arrowWith: string = "arrow_drop_down";
  travelings = ['1', '2', '3']
  traveling: travelingPassenger = new travelingPassenger(null, 0, "", "", null, null, null, null, 0, "", "", 0, 0, 0, 0, true);
  travelingsAttached: travelingPassenger[] = [];
  travelingsNotAttached: travelingPassenger[] = [];
  registeredTravelings: Registeration[] = [];
  message: string = "";
  animal: string;
  name: string;
  id: number;

  constructor(
    private router: Router,
    private travelingPassengerService: TravelingPassengerService,
    private registerationService: RegisterationService,
    private reportOrDelete: Auth,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.getTravelings();
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
  getTravelings() {
    this.travelingPassengerService.getTravelingsAttached().subscribe((state: travelingPassenger[]) => {
      this.travelingsAttached = state,
        state ?
          this.message = "---אין נסיעות במאגר---" :
          console.log(this.travelingsAttached)

    });
    this.travelingPassengerService.getTravelingsNotAttached().subscribe((state: travelingPassenger[]) => {
      this.travelingsNotAttached = state,
        state ?
          this.message = "---אין נסיעות במאגר---" :
          console.log(this.travelingsNotAttached)
    });
  }

  openWithNotJoining() {
    if (this.openWithNot) {
      this.openWithNot = 0;
      this.arrowWithNot = "arrow_drop_down";
    }
    else {
      this.openWithNot = 2;
      this.arrowWithNot = "arrow_drop_up";
    }
  }

  openWithJoining() {
    if (this.openWith) {
      this.openWith = 0;
      this.arrowWith = "arrow_drop_down";
    }
    else {
      this.openWith = 1;
      this.arrowWith = "arrow_drop_up";
    }
  }

  deleteTravelingReg(TravelingIdPassenger: number) {
    console.log(TravelingIdPassenger);

    const dialogRef = this.dialog.open(DeleteTravelingRegPComponent, {
      width: '270px',

      data: { name: this.name, animal: this.animal, id: TravelingIdPassenger }
    });
    dialogRef.disableClose = true;
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.animal = result;
    });
  }

  deleteTraveling(TravelingIdPassenger: number) {
    console.log(TravelingIdPassenger);

    const dialogRef = this.dialog.open(DeleteTravelingPComponent, {
      width: '270px',

      data: { name: this.name, animal: this.animal, id: TravelingIdPassenger }
    });
    dialogRef.disableClose = true;
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.animal = result;
    });
  }


  updateTraveling(TravelingIdPassenger: number) {
    this.router.navigate(['/edit-traveling-p/' + TravelingIdPassenger]);
  }


  addComplaint(TravelingIdPassenger: number) {
    const dialogRef = this.dialog.open(ReportComponent, {
      width: '270px',

      data: { name: this.name, animal: this.animal, id: TravelingIdPassenger }
    });
    dialogRef.disableClose = true;
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.animal = result;
    });

  }
}
