import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterationDateRange } from '../entities/RegisterationDateRange';
import { Observable } from 'rxjs';
import { Passenger } from '../entities/passenger';

@Injectable({
  providedIn: 'root'
})
export class RegistretionDateRangeService {

  api = 'https://localhost:44305/api/RegisterationDateRange';
  constructor(private http: HttpClient) { }
 
  
  getRegisterations(id: number): Observable<RegisterationDateRange[]> {
    return this.http.get<RegisterationDateRange[]>(`${this.api + "/RegisterationDates/"}${id}`);
  }

  // getRegisterationsByPassenger(TravelingIdPassenger: number): Observable<RegisterationDateRange> {
  //   return this.http.get<RegisterationDateRange>(`${this.api + "/Registerations/"}${TravelingIdPassenger}`);
  // }

  // getRegisterationsByDriver(TravelingIdDriver: number): Observable<RegisterationDateRange> {
  //   return this.http.get<RegisterationDateRange>(`${this.api + "/RegisterationsD/"}${TravelingIdDriver}`);
  // }

  // addRegisteration(registeration: RegisterationDateRange) {
  //   return this.http.post<any>(this.api + "/add", registeration);
  // }
}
 
