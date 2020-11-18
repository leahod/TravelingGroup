export class  Payment  {
    public Id: number;
    public IdRegisteration: number;
    public IdPaymentKind: number;
    public PaymentDate: Date;
    public SumPay: number;

    constructor(  Id: number, IdRegisteration: number,  IdPaymentKind: number, PaymentDate: Date, SumPay: number)
          {
          this.Id = Id;
        this.IdRegisteration = IdRegisteration;
        this.IdPaymentKind=IdPaymentKind;
        this.PaymentDate=PaymentDate;
        this.SumPay=SumPay;
         
    }
}