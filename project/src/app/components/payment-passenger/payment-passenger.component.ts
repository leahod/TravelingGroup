import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PaymentService } from 'src/app/services/payment.service';
import { Payment } from 'src/app/entities/payment';
import { PaymentKind } from 'src/app/entities/paymentKind';

@Component({
  selector: 'app-payment-passenger',
  templateUrl: './payment-passenger.component.html',
  styleUrls: ['./payment-passenger.component.scss']
})
export class PaymentPassengerComponent implements OnInit {

  payments: Payment  [] = [];
  paymentResson : string='';
    
  constructor
    (
      private router: Router,
      private paymentService: PaymentService,
    ) { }

  ngOnInit() {
    this.getPayments();
  }

  getPayments() {
    this.paymentService.getPaymentByIdP().subscribe((state: Payment[]) => {
      this.payments = state ; 
    });
  
    
  }
  getResson(idKindPay: number)
  {
    switch(idKindPay) {
      case (1):
       return PaymentKind [1] ;
        case (2):
          return PaymentKind [2] ;
           case (3):
            return PaymentKind [3] ;
  }

  
  
}

}
