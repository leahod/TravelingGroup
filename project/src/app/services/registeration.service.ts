import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Registeration } from '../entities/registeration';
import { Observable } from 'rxjs';
import { Passenger } from '../entities/passenger';
import { travelingPassenger } from '../entities/travelingPassenger';
import { TravelingPassengerService } from './traveling-passenger.service';
import { travelingDriver } from '../entities/travelingDriver';

@Injectable({
  providedIn: 'root'
})
export class RegisterationService {

  passenger: Passenger;

  api = 'https://localhost:44305/api/Registeration';

  constructor(private http: HttpClient) { }

  getRegisterations(identity: string): Observable<Registeration> {
    return this.http.get<Registeration>(`${this.api + "/Registerations/"}${identity}`);
  }

  getRegisterationsByPassenger(TravelingIdPassenger: number): Observable<Registeration> {
    return this.http.get<Registeration>(`${this.api + "/Registerations/"}${TravelingIdPassenger}`);
  }

  getRegisterationsByDriver(TravelingIdDriver: number): Observable<Registeration> {
    return this.http.get<Registeration>(`${this.api + "/RegisterationsD/"}${TravelingIdDriver}`);
  }

  addRegisteration(registeration: Registeration) {
    return this.http.post<any>(this.api + "/add", registeration);
  }

 deleteRegisterationP(TravelingPassenger: travelingPassenger) {
    debugger;
    return this.http.post<any>(this.api + "/deleteRangeRegP", TravelingPassenger);
  }

  deleteRegisterationD(TravelingDriver: travelingDriver) {
     
    return this.http.post<any>(this.api + "/deleteRangeRegD", TravelingDriver);
  }
}
