import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StatisticsServiceService {
  
  
  api = 'https://localhost:44305/api/statistics';

  constructor(private http: HttpClient) { }

  getGender(): Observable<number[]> {
    return this.http.get<number[]>(this.api + "/Gender");
  }

  getDays(): Observable<number[]> {
    return this.http.get<number[]>(this.api + "/Days");
  }

  getAvgPassengers(): Observable<number> {
    return this.http.get<number>(this.api + "/AvgPassengers");
  }

  getTravelCost(): Observable<number[]> {
    return this.http.get<number[]>(this.api + "/TravelCost");
  }

}
