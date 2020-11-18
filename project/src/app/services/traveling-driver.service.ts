import { Injectable } from '@angular/core';
import { Driver } from '../entities/driver';
import { HttpClient } from '@angular/common/http';
import { travelingDriver } from '../entities/travelingDriver';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TravelingDriverService {


  api = 'https://localhost:44305/api/travelingDriver';
  driver: Driver;
   id= 20;
  constructor(private http: HttpClient) { }

  addTraveling(traveling: travelingDriver)  {
    return this.http.post<any>(this.api + "/add", traveling);
  }

  getTravelings(): Observable<travelingDriver[]> {
    this.driver = JSON.parse(localStorage.getItem("driver"));
    return this.http.get<travelingDriver[]>(`${this.api + "/Travelings/"}${this.driver.Id}`);
  }

  getTravelingById(id: number): Observable<travelingDriver> {
    return this.http.get<travelingDriver>(`${this.api + "/travelingD/"}${id}`);
  }
   
  
  updateTraveling(traveling: travelingDriver): Observable<number> {
    return this.http.put<number>(this.api + "/Update", traveling);
  }
 
  sendMail(idTravelingD: number, idTravelingP: number) {
    return this.http.post(this.api + "/sendMail", { idTravelingD: idTravelingD, idTravelingP: idTravelingP });
  }

  getTravelingsAttached(): Observable<travelingDriver[]> {
    this.driver = JSON.parse(localStorage.getItem("driver"));
    return this.http.get<travelingDriver[]>(`${this.api + "/TravelingsAttached/"}${this.driver.Id}`);
  }
  getTravelingsNotAttached(): Observable<travelingDriver[]> {
    this.driver = JSON.parse(localStorage.getItem("driver"));
    return this.http.get<travelingDriver[]>(`${this.api + "/TravelingsNotAttached/"}${this.driver.Id}`);
  }

  deleteTraveling(TravelingDriver: travelingDriver) {
     
    return this.http.post<any>(this.api + "/delete", TravelingDriver);
  }
}
