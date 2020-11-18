import { Component, OnInit, Inject } from '@angular/core';
import { RegisterationDateRange } from 'src/app/entities/RegisterationDateRange';
import { ActivatedRoute } from '@angular/router';
import { TravelReportingService } from 'src/app/services/travel-reporting.service';
import swal from 'sweetalert';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { Auth } from 'src/app/services/auth';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DialogData } from '../exists-traveling-d/exists-traveling-d.component';


@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent implements OnInit {

  traveling: RegisterationDateRange = new RegisterationDateRange(0, null, true, 0, 0, false);
  date: Date = new Date();

  constructor(
    private spinnerService: Ng4LoadingSpinnerService, 
    private activatedRoute: ActivatedRoute, 
    private travelReportService: TravelReportingService,
    private report: Auth,
    public dialogRef: MatDialogRef<ReportComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}
  
  ngOnInit() {
    this.setTraveling();
  }
  close()
  {
    this.dialogRef.close();
  }

  setTraveling() {
    this.traveling.Id = this.data.id;
  } 

  

  complaintTraveling() {
     
    console.log(this.traveling.DateInRange);
    console.log(this.date);
    if (this.traveling.DateInRange > new Date(Date.now()))  
    {
    //if (this.traveling.DateInRange > this.date) {
       
      swal({
        title: "תאריך שגוי",
        text: "הזנת תאריך גדול מתאריך נוכחי ",
        icon: "error",

      });
    }
    else {

      this.spinnerService.show();
      this.travelReportService.addComplaint(this.traveling).subscribe(x => {
        this.spinnerService.hide(),
        this.close(),
        swal({
          title: "תלונתך נשמרה במערכת",
          text: "יוחזר החזר כספי לפי תקנון האתר ",
          icon: "success",

        })
      })

    };
   this.report.report=0;
  }

}
