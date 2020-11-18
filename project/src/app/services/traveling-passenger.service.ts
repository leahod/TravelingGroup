import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { travelingPassenger } from '../entities/travelingPassenger';
import { Observable } from 'rxjs';
import { Passenger } from '../entities/passenger';

@Injectable({
  providedIn: 'root'
})
export class TravelingPassengerService {

  api = 'https://localhost:44305/api/travelingPassenger';
  passenger: Passenger;

  constructor(private http: HttpClient) { }

  addTraveling(traveling: travelingPassenger): Observable<number> {
    return this.http.post<number>(this.api + "/add", traveling);
  }

  getTravelings(): Observable<travelingPassenger[]> {
    this.passenger = JSON.parse(localStorage.getItem("passenger"));
    return this.http.get<travelingPassenger[]>(`${this.api + "/Travelings/"}${this.passenger.Id}`);
  }

  getTravelingById(id: number): Observable<travelingPassenger> {
    return this.http.get<travelingPassenger>(`${this.api + "/Traveling/"}${id}`);
  }

  updateTraveling(traveling: travelingPassenger): Observable<number> {
    return this.http.put<number>(this.api + "/Update", traveling);
  }

  // deleteTraveling(travelingPassengerId: number): Observable<travelingPassenger> {
  //   return this.http.delete<any>(`${this.api + "/Delete/"}${travelingPassengerId}`);
  // }

  sendMail(idTravelingD: number, idTravelingP: number) {
    return this.http.post(this.api + "/sendMail", { idTravelingD: idTravelingD, idTravelingP: idTravelingP });
  }

  getTravelingsAttached(): Observable<travelingPassenger[]> {
    this.passenger = JSON.parse(localStorage.getItem("passenger"));
    return this.http.get<travelingPassenger[]>(`${this.api + "/TravelingsAttached/"}${this.passenger.Id}`);
  }
  getTravelingsNotAttached(): Observable<travelingPassenger[]> {
    this.passenger = JSON.parse(localStorage.getItem("passenger"));
    return this.http.get<travelingPassenger[]>(`${this.api + "/TravelingsNotAttached/"}${this.passenger.Id}`);
  }
  deleteTraveling(TravelingPassenger: travelingPassenger) {
     
    return this.http.post<any>(this.api + "/delete", TravelingPassenger);
  }
}
