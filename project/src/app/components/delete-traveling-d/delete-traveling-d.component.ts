import { Component, OnInit, Inject } from '@angular/core';
import { travelingDriver } from 'src/app/entities/travelingDriver';
import { ActivatedRoute } from '@angular/router';
import { RegisterationService } from 'src/app/services/registeration.service';
import { RegisterationDateRange } from 'src/app/entities/RegisterationDateRange';
import { TravelingDriverService } from 'src/app/services/traveling-driver.service'
import { Auth } from 'src/app/services/auth';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from '../exists-traveling-d/exists-traveling-d.component';

@Component({
  selector: 'app-delete-traveling-d',
  templateUrl: './delete-traveling-d.component.html',
  styleUrls: ['./delete-traveling-d.component.scss']
})
export class DeleteTravelingDComponent implements OnInit {

  traveling: travelingDriver = new travelingDriver(null, 0, "", "", null, null, null, 0, "", "", 0, 0, 0, 0, 0, 0, true);
  travelingIdD: number;
  re: RegisterationDateRange[] = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private registretionService: RegisterationService,
    private travelingDriverService: TravelingDriverService,
    private deleteT: Auth,
    public dialogRef: MatDialogRef<DeleteTravelingDComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
    this.setTraveling();
  }

  setTraveling() {
    this.travelingIdD = this.data.id;
    this.travelingDriverService.getTravelingById(this.travelingIdD)
      .subscribe((t: travelingDriver) => { this.traveling = t; });
    this.traveling.TravelingIdDriver = this.data.id;
  }

  deleteTraveling() {
    this.travelingDriverService.deleteTraveling(this.traveling).subscribe(x => console.log("delete"));
    this.deleteT.delete = 0;
  }
  
  close() {
    this.dialogRef.close();
  }
}


