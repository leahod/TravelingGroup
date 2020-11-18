import { Component, OnInit, Inject } from '@angular/core';
import { travelingDriver } from 'src/app/entities/travelingDriver';
import { RegisterationService } from 'src/app/services/registeration.service';
import { ActivatedRoute } from '@angular/router';
import { RegisterationDateRange } from 'src/app/entities/RegisterationDateRange';
import { TravelingDriverService } from 'src/app/services/traveling-driver.service';
import { Auth } from 'src/app/services/auth';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from '../exists-traveling-d/exists-traveling-d.component';
import swal from 'sweetalert';

@Component({
  selector: 'app-delete-traveling-reg-d',
  templateUrl: './delete-traveling-reg-d.component.html',
  styleUrls: ['./delete-traveling-reg-d.component.scss']
})
export class DeleteTravelingRegDComponent implements OnInit {

  traveling: travelingDriver = new travelingDriver(null, 0, "", "", null, null, null, 0, "", "", 0, 0, 0, 0, 0, 0, true);
  travelingIdD: number;
  re: RegisterationDateRange[] = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private registretionService: RegisterationService,
    private travelingDriverService: TravelingDriverService,
    private deleteT: Auth,
    public dialogRef: MatDialogRef<DeleteTravelingRegDComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) { }

  ngOnInit() {
    this.setTraveling();
  }

  setTraveling() {
    this.travelingIdD = this.data.id;
    this.travelingDriverService.getTravelingById(this.travelingIdD)
      .subscribe((t: travelingDriver) => { this.traveling = t; console.log("bsgf") });
    this.traveling.TravelingIdDriver = this.data.id;
  }

  deleteTraveling() {
    this.registretionService.deleteRegisterationD(this.traveling).subscribe(x => {
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