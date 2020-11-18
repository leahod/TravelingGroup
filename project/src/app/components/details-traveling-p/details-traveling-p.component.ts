import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { TravelingPassengerService } from 'src/app/services/traveling-passenger.service';
import { travelingPassenger } from 'src/app/entities/travelingPassenger';
import { RegisterationService } from 'src/app/services/registeration.service';
import { Registeration } from 'src/app/entities/registeration';

@Component({
  selector: 'app-details-traveling-p',
  templateUrl: './details-traveling-p.component.html',
  styleUrls: ['./details-traveling-p.component.scss']
})
export class DetailsTravelingPComponent implements OnInit {

  id: number;
  public traveling: travelingPassenger = new travelingPassenger(null, 0, "", "", null, null, null, null, 0, "", "", 0, 0, 0, 0, true);
  public registerations: Registeration = new Registeration(0, 0, 0);

  constructor(
    private activatedRoute: ActivatedRoute,
    private travelingPassengerService: TravelingPassengerService,
  ) { }

  ngOnInit() {
    this.setTraveling();
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
  setTraveling() {
    this.activatedRoute.url.subscribe(url => {
      this.id = +this.activatedRoute.snapshot.paramMap.get('id')
    });
    console.log(this.id);
    this.travelingPassengerService.getTravelingById(this.id)
      .subscribe((state: travelingPassenger) => this.traveling = state);
  }

  SaveDetails() {
    this.travelingPassengerService.updateTraveling(this.traveling).subscribe();
  }
}
