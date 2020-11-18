import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RegisterationService } from '../../services/registeration.service';
import { RegisterationDateRange } from '../../entities/RegisterationDateRange'
import { travelingPassenger } from 'src/app/entities/travelingPassenger';
import { TravelingPassengerService } from 'src/app/services/traveling-passenger.service';
import { Auth } from 'src/app/services/auth';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from '../exists-traveling-d/exists-traveling-d.component';
import swal from 'sweetalert';


@Component({
  selector: 'app-delete-traveling-p',
  templateUrl: './delete-traveling-p.component.html',
  styleUrls: ['./delete-traveling-p.component.scss']
})
export class DeleteTravelingPComponent implements OnInit {

  traveling: travelingPassenger = new travelingPassenger(null, 0, "", "", null, null, null, null, 0, "", "", 0, 0, 0, 0, true);
  travelingIdP: number;
  re: RegisterationDateRange[] = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private registretionService: RegisterationService,
    private travelingPassengerService: TravelingPassengerService,
    private deleteT: Auth,
    public dialogRef: MatDialogRef<DeleteTravelingPComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) { }

  ngOnInit() {
    this.setTraveling();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  setTraveling() {
    this.travelingIdP = this.data.id;
    this.travelingPassengerService.getTravelingById(this.travelingIdP)
      .subscribe((t: travelingPassenger) => { this.traveling = t });
    this.traveling.TravelingIdPassenger = this.data.id;
  }

  deleteTraveling() {
    this.travelingPassengerService.deleteTraveling(this.traveling).subscribe(x => {
      this.close(),
        swal("! מחיקת הנסיעות בטווח הסתיימה בהצלחה", "נסיעה בטוחה", "success")
    }
    );
    this.deleteT.delete = 0;
  }
  
  close() {
    this.dialogRef.close();

  }
}
