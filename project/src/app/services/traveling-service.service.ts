import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { travelingDriver } from '../entities/travelingDriver';
import { Observable } from 'rxjs';
import { Driver } from '../entities/driver';

@Injectable({
  providedIn: 'root'
})
export class TravelingServiceService {


  api = 'https://localhost:44305/api/travelingDriver';
  driver: Driver;

  constructor(private http: HttpClient) { }

  addTraveling(traveling: travelingDriver): Observable<travelingDriver> {
    return this.http.post<any>(this.api + "/add", traveling);
  }

  getTravelingsToP(idTravelingPassenger: number): Observable<travelingDriver[]> {
    return this.http.get<travelingDriver[]>(`${this.api + "/Travelings/"}${idTravelingPassenger}`);
  }

  sendMail(idTravelingD: number, idTravelingP: number) {
    return this.http.post(this.api + "/sendMail", { idTravelingD: idTravelingD, idTravelingP: idTravelingP });
  }

  getDriversSuitable(idTravelingPassenger: number) {
    return this.http.get<travelingDriver[]>(`${this.api + "/driversSuitable/"}${idTravelingPassenger}`);
  }

  getTravelingDriver(idTravelingDriver: number): Observable<travelingDriver> {
    return this.http.get<travelingDriver>(`${this.api + "/Traveling/"}${idTravelingDriver}`);
  }

  getTravelings(): Observable<travelingDriver[]> {
    this.driver = JSON.parse(localStorage.getItem("driver"));
    return this.http.get<travelingDriver[]>(`${this.api + "/Travelings/"}${this.driver.Id}`);
  }

}
