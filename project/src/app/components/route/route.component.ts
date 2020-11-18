import { Component, OnInit } from '@angular/core';
import { ILatLng } from '../directions-map.directive';
import { } from '@agm/core/services/google-maps-types';
import { RouteService } from 'src/app/services/route.service';
import { WayPoint } from 'src/app/entities/WayPoint';
import { Point } from 'src/app/entities/Point';
import { ActivatedRoute } from '@angular/router';
import { Way } from 'src/app/entities/way';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
declare var google;



@Component({
  selector: 'app-route',
  templateUrl: './route.component.html',
  styleUrls: ['./route.component.scss']
})
export class RouteComponent implements OnInit {

  lat = 41.85;
  lng = -87.65;

  origin = { lat: 39.0921167, lng: -94.8559005 };
  destination = { lat: 41.8339037, lng: -87.8720468 };

  waypoints = [];
  way: WayPoint = new WayPoint(0, 0, 0, 0, []);

  id: number = 0;
  way1 = new Way(0, 0);

  constructor(
    private routeService: RouteService,
     private activatedRoute: ActivatedRoute, 
     private spinnerService: Ng4LoadingSpinnerService,
     ) { }
   
  ngOnInit() {
  this.spinnerService.show();
    this.activatedRoute.url.subscribe(url => {
      this.id = +this.activatedRoute.snapshot.paramMap.get('id')
    });

    this.origin = { lat: this.way.LatSource, lng: this.way.LngSource };
    this.destination = { lat: this.way.LatDestination, lng: this.way.LngDestination };
    this.routeService.getRoute(this.id).subscribe(((w: WayPoint) => { this.way = w; this.setWay();this.spinnerService.hide(); }));
  }

  setWay() {

    this.origin = { lat: this.way.LatSource, lng: this.way.LngSource };
    this.destination = { lat: this.way.LatDestination, lng: this.way.LngDestination };
  
    for (let o of this.way.ListPoint) {
      this.waypoints.push({
        location: {
          lat: o.Lat,
          lng: o.Lng
        }
      });
    }
  }

}


