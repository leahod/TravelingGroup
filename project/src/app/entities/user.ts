export class User {
    
    public Identity: string;
    public Name: string;
    public Mail:string;
    public Gender: boolean;
    public Cellphone:string;
    public  CreditCardNumber : string ;
    public  Validity : Date ;
    public  Cvv  :string ;
    public  IdCardOwner :string;  

    constructor(identity:string, name:string,mail:string,gender: boolean , Cellphone:string,
         CreditCardNumber : string  ,Validity : Date, Cvv  :string ,   IdCardOwner :string  ) {
        this.Identity = identity;
        this.Name = name;
        this.Mail=mail;
        this.Gender=gender;
        this.Cellphone = Cellphone;
        this.CreditCardNumber =CreditCardNumber;
        this.Validity = Validity;
        this.Cvv = Cvv;
        this.IdCardOwner= IdCardOwner;
    }
}