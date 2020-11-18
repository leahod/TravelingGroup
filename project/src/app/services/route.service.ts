import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WayPoint } from '../entities/WayPoint';
import { Observable } from 'rxjs';
import { Point } from '../entities/Point';
import { Way } from '../entities/way';

@Injectable({
  providedIn: 'root'
})
export class RouteService {

  
  api = 'https://localhost:44305/api/route';
  points :Point []=[];
  
 constructor(private http: HttpClient) { }
 
 getRoute(idTravel:number): Observable<WayPoint> {
   
 return this.http.get<WayPoint>(`${this.api + "/getRoute/"}${idTravel}`);
 }
 
}
