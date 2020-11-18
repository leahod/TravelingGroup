import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Driver } from '../entities/driver';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DriverServiceService {

  api = 'https://localhost:44305/api/drivers';

  constructor(private http: HttpClient) { }

  addDriver(driver: Driver): Observable<Driver> {
    return this.http.post<any>(this.api + "/add", driver);
  }

  getDrivers(): Observable<Driver[]> {
    return this.http.get<Driver[]>(this.api + "/Drivers");
  }

  getDriverById(identity: string): Observable<Driver> {
    return this.http.get<Driver>(`${this.api + "/Driver/"}${identity}`)
      ;
  }

  updateDriver(driver: Driver): Observable<Driver> {
    return this.http.put<any>(`${this.api + "/update/"}${driver.Identity}`, driver);
  }

}
