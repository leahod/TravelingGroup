import { Component, OnInit, Inject } from '@angular/core';
import { travelingPassenger } from 'src/app/entities/travelingPassenger';
import { ActivatedRoute } from '@angular/router';
import { RegisterationDateRange } from 'src/app/entities/RegisterationDateRange';
import { RegisterationService } from 'src/app/services/registeration.service';
import { TravelingPassengerService } from 'src/app/services/traveling-passenger.service';
import { Auth } from 'src/app/services/auth';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from '../exists-traveling-d/exists-traveling-d.component';
import swal from 'sweetalert';

@Component({
  selector: 'app-delete-traveling-reg-p',
  templateUrl: './delete-traveling-reg-p.component.html',
  styleUrls: ['./delete-traveling-reg-p.component.scss']
})
export class DeleteTravelingRegPComponent implements OnInit {

  traveling: travelingPassenger = new travelingPassenger(null, 0, "", "", null, null, null, null, 0, "", "", 0, 0, 0, 0, true);
  travelingIdP: number;
  re: RegisterationDateRange[] = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private registretionService: RegisterationService,
    private travelingPassengerService: TravelingPassengerService,
    private deleteT: Auth,
    public dialogRef: MatDialogRef<DeleteTravelingRegPComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) { }


  ngOnInit() {
    this.setTraveling();
  }

  setTraveling() {
    this.travelingIdP = this.data.id;
    this.travelingPassengerService.getTravelingById(this.travelingIdP)
      .subscribe((t: travelingPassenger) => { this.traveling = t });
    this.traveling.TravelingIdPassenger = this.data.id;

  }

  deleteTraveling() {
    this.registretionService.deleteRegisterationP(this.traveling).subscribe(
      x => {
        this.close(),
          swal("! מחיקת הנסיעות בטווח הסתיימה בהצלחה", "נסיעה בטוחה", "success")
      }
    );
    this.deleteT.deleteReg = 0;
  }
  
  close() {
    this.dialogRef.close();
  }
}
