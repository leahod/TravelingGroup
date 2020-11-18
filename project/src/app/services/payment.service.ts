import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Payment } from '../entities/payment';
import { Passenger } from '../entities/passenger';
import { Driver } from '../entities/driver';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
   
  
  api = 'https://localhost:44305/api/Payment';
   passenger : Passenger;
   driver :Driver;

  constructor(private http: HttpClient) { }

  // addTraveling(traveling: travelingPassenger): Observable<number> {
  //   return this.http.post<number>(this.api + "/add", traveling);
  // }

  getPaymentByIdP(): Observable<Payment[]> {
    this.passenger = JSON.parse(localStorage.getItem("passenger"));
    return this.http.get<Payment[]>(`${this.api + "/PaymentsByIdP/"}${this.passenger.Id}`);
  }
  getPaymentByIdD(): Observable<Payment[]> {
    this.driver = JSON.parse(localStorage.getItem("driver"));
    return this.http.get<Payment[]>(`${this.api + "/PaymentsByIdD/"}${this.driver.Id}`);
  }
  

   
}
