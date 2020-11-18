import { User } from './user';

export class Passenger extends User {
    public Id: number;
    public Identity: string;

    constructor(Id:number,Identity:string,user: User) {
        super(user.Identity,user.Name,user.Mail,user.Gender,user.Cellphone,
            user.CreditCardNumber,user.Validity, user.Cvv, user.IdCardOwner);
        this.Id=Id;
        this.Identity = Identity;
        
    }
}