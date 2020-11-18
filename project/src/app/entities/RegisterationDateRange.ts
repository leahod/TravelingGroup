export class RegisterationDateRange {
    public Id: number;
    public DateInRange: Date; 
    public IsActive: boolean;
    public NumPassengers: number;
    public NumComplainants: number;
    public IsComplain: boolean;
      
    constructor(Id: number , DateInRange: Date , IsActive: boolean,  NumPassengers: number,NumComplainants: number,IsComplain: boolean)
       {
        this.Id=Id;
        this.DateInRange=DateInRange;
        this.IsActive = IsActive;
        this.NumPassengers =NumPassengers;
        this.NumComplainants =NumComplainants;
        this.IsComplain =IsComplain;
       
    }
}