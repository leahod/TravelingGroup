
 import {Point } from './Point';
  
export class WayPoint  {
   
    public LatSource: number;
    public LatDestination:number;
    public LngSource: number;
    public LngDestination:number;
    public ListPoint: Point[] ;
    
    constructor( LatSource: number, LatDestination:number, LngSource: number, LngDestination:number,ListPoint: Point[]  )
       { 
        this.LatSource=LatSource;
        this.LatDestination = LatDestination;
        this.LngSource=LngSource;
        this.LngDestination = LngDestination;
        this.ListPoint = ListPoint;
      
    }
 
}
