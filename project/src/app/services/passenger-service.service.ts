import { Injectable } from '@angular/core';
import { Passenger } from '../entities/passenger';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PassengerServiceService {

  api = 'https://localhost:44305/api/passengers';

  constructor(private http: HttpClient) { }

  addPassenger(passenger: Passenger): Observable<Passenger> {
    return this.http.post<any>(this.api + "/add", passenger);
  }

  getPassengers(): Observable<Passenger[]> {
    return this.http.get<Passenger[]>(this.api + "/Passengers");
  }

  getPassengerById(identity: string): Observable<Passenger> {
    return this.http.get<Passenger>(`${this.api + "/Passenger/"}${identity}`);
  }

  updatePassenger(passenger: Passenger): Observable<Passenger> {
    return this.http.put<any>(`${this.api + "/update/"}${passenger.Identity}`, passenger);
  }

}
