import { Component, OnInit } from '@angular/core';
import {ILatLng} from '../directions-map.directive';
import {  } from '@agm/core/services/google-maps-types';
declare var google; 

@Component({
  selector: 'app-google-map',
  templateUrl: './google-map.component.html',
  styleUrls: ['./google-map.component.scss']
})
export class GoogleMapComponent implements OnInit {
n:number = 9;
  // Washington, DC, USA
   

  // origin: ILatLng = {
    
  //   latitude: 38.889931,
  //   longitude: -77.009003
  // };
  
  // // New York City, NY, USA
  // destination: ILatLng = {
  //   latitude: 40.730610,
  //   longitude: -73.935242
  // };
  // waypoint:ILatLng[]=[{latitude: 40.730610,
  //   longitude: -73.935242},{latitude: 45.730610,
  //     longitude: -71.935242}];
  // displayDirections = true;
  // zoom = 14;



  lat = 41.85;
  lng = -87.65;

  origin = { lat: 39.0921167, lng: -94.8559005};
  destination = { lat: 41.8339037, lng: -87.8720468 };
  // waypoints   = [
  //   {location: { lat: 39.0921167, lng: -94.8559005 }},
  //    {location: { lat: 41.8339037, lng: -87.8720468 }}
    
  // ];
 // waypoints  =[];
  // waypoints  =[{latitude: 39.0921167,
  //       longitude:  -94.8559005},{latitude: 41.8339037,
  //        longitude:  -87.8720468}];
  
  waypoints = [];

  constructor() { 
 
  } 

  ngOnInit() {
   
    
      this.waypoints.push({
        location: {   lat: 42.36354447989272,
         lng:-71.08023562010727},
      
    });
    this.waypoints.push({
      location:{ lat: 38.0921167,
        lng:  -94.8559005}
    
  });
  this.waypoints.push({
    location:{ lat: 33.0921167,
      lng:  -91.8559005}
  
});
    //  const geocoder = new google.maps.Geocoder();

    // geocoder.geocode({ address: "מגדלי עזריאלי, דרך מנחם בגין, תל אביב יפו" }, (results, status) => {
    //   if (status === "OK") {
    //   console.log(results);
    //   } else {
    //     alert("Geocode was not successful for the following reason: " + status);
    //   }
    // });
  }

}
 
  
 