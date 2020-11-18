import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegistretionDateRangeService } from './registretion-date-range.service';
import { RegisterationDateRange } from '../entities/RegisterationDateRange';

@Injectable({
  providedIn: 'root'
})
export class TravelReportingService {
   
  api = 'https://localhost:44305/api/travelReporting';

  constructor(private http: HttpClient) { }

  addComplaint(traveling: RegisterationDateRange)  {
    return this.http.post<any>(this.api + "/add", traveling);
  }
}
