import { Component, OnInit } from '@angular/core';
import { travelingDriver } from 'src/app/entities/travelingDriver';
import { Router } from '@angular/router';
import { TravelingDriverService } from 'src/app/services/traveling-driver.service';
import { RegisterationService } from 'src/app/services/registeration.service';
import { Auth } from 'src/app/services/auth';
import { MatDialog } from '@angular/material/dialog';
import { DeleteTravelingDComponent } from '../delete-traveling-d/delete-traveling-d.component';
import { DeleteTravelingRegDComponent } from '../delete-traveling-reg-d/delete-traveling-reg-d.component';
export interface DialogData {
  animal: string;
  name: string;
  id: number;
}
@Component({
  selector: 'app-exists-traveling-d',
  templateUrl: './exists-traveling-d.component.html',
  styleUrls: ['./exists-traveling-d.component.scss']
})

export class ExistsTravelingDComponent implements OnInit {


  openWithNot: number = 0;
  openWith: number = 0;
  arrowWithNot: string = "arrow_drop_down";
  arrowWith: string = "arrow_drop_down";
  travelings = ['1', '2', '3']
  traveling: travelingDriver = new travelingDriver(null, 0, "", "", null, null, null, 0, "", "", 0, 0, 0, 0, 0, 0, true);
  message: string = "";
  travelingsAttached: travelingDriver[] = [];
  travelingsNotAttached: travelingDriver[] = [];
  animal: string;
  name: string;
  id: number;

  constructor(
    private router: Router,
    private travelingDriverService: TravelingDriverService,
    private registerationService: RegisterationService,
    private deleteT: Auth,
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
    this.travelingDriverService.getTravelingsAttached().subscribe((state: travelingDriver[]) => {
      this.travelingsAttached = state,
        state ?
          this.message = "---אין נסיעות במאגר---" :
          console.log(this.travelingsAttached)
    });
    this.travelingDriverService.getTravelingsNotAttached().subscribe((state: travelingDriver[]) => {
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

  deleteTravelingReg(TravelingIdDriver: number) {
    const dialogRef = this.dialog.open(DeleteTravelingRegDComponent, {
      width: '270px',

      data: { name: this.name, animal: this.animal, id: TravelingIdDriver }
    });
    dialogRef.disableClose = true;
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.animal = result;
    });
  }

  deleteTraveling(TravelingIdDriver: number) {
    const dialogRef = this.dialog.open(DeleteTravelingDComponent, {
      width: '270px',

      data: { name: this.name, animal: this.animal, id: TravelingIdDriver }
    });
    dialogRef.disableClose = true;
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.animal = result;
    });
  }


}
