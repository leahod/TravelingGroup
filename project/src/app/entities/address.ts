 
export class Address1 {
    public Id: number;
    public City: string;
    public Street: string;
    public HouseNumber:number;

    constructor(Id:number,City:string, Street:string,HouseNumber:number ) {
        this.Id=Id;
        this.City = City;
        this.Street = Street;
        this.HouseNumber=HouseNumber;
    }
}