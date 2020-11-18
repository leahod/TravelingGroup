export class Registeration {
    public id: number;
    public travelingIdDriver: number;
    public travelingIdPassenger: number;
   

    constructor(id:number,travelingIdDriver:number, travelingIdPassenger:number) {
        this.id=id;
        this.travelingIdDriver = travelingIdDriver;
        this.travelingIdPassenger = travelingIdPassenger;
       
    }
}