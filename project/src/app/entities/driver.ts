import { User } from './user';

export class Driver extends User{
    public Id: number;
    public Identity: string;
    public NumberOfSeats: number;
    public CarDescription:string;
    

    constructor(Id:number,Identity:string, NumberOfSeats:number,CarDescription:string,
         user: User ) {
        super(user.Identity,user.Name,user.Mail,user.Gender,user.Cellphone,user.CreditCardNumber,user.Validity,
            user.Cvv, user.IdCardOwner);
        this.Id=Id;
        this.Identity = Identity;
        this.NumberOfSeats = NumberOfSeats;
        this.CarDescription=CarDescription;
       
    }
}