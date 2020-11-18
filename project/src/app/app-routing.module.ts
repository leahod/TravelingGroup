import { NgModule } from '@angular/core';
import { Routes, RouterModule, Router } from '@angular/router';
import { LogInComponent } from './components/log-in/log-in.component';
import { NewUserComponent } from './components/new-user/new-user.component';
import { NewDriverComponent } from './components/new-driver/new-driver.component';
import { ExistsUserComponent } from './components/exists-user/exists-user.component';
import { ExistsDriverComponent } from './components/exists-driver/exists-driver.component'
import { ExistsPassengerComponent } from './components/exists-passenger/exists-passenger.component';
import { NewTravelingDComponent } from './components/new-traveling-d/new-traveling-d.component';
import { NewTravelingPComponent } from './components/new-traveling-p/new-traveling-p.component';
import { ExistsTravelingPComponent } from './components/exists-traveling-p/exists-traveling-p.component';
import { DetailsTravelingPComponent } from './components/details-traveling-p/details-traveling-p.component';
import { SuitableDriversComponent } from './components/suitable-drivers/suitable-drivers.component';
import { ConfirmPassengerComponent } from './components/confirm-passenger/confirm-passenger.component'
import { ConfirmDriverComponent } from './components/confirm-driver/confirm-driver.component';
import { MapComponent } from './components/map/map.component';
import { ExistsTravelingDComponent } from './components/exists-traveling-d/exists-traveling-d.component'
import { AboutComponent } from './components/about/about.component'
import { EditUserComponent } from './components/edit-user/edit-user.component';
import { EditDriverComponent } from './components/edit-driver/edit-driver.component';
import { Auth } from './services/auth';
import {GoogleMapComponent} from '../app/components/google-map/google-map.component'
import { StatisticsComponent } from './components/statistics/statistics.component';
import { DeleteTravelingPComponent } from './components/delete-traveling-p/delete-traveling-p.component';
import { DeleteTravelingDComponent } from './components/delete-traveling-d/delete-traveling-d.component';
import { DeleteTravelingRegPComponent } from './components/delete-traveling-reg-p/delete-traveling-reg-p.component';
import {PaymentPassengerComponent} from './components/payment-passenger/payment-passenger.component'
import { DeleteTravelingRegDComponent } from './components/delete-traveling-reg-d/delete-traveling-reg-d.component';
import { ReportComponent } from './components/report/report.component';
import { PaymentDriverComponent } from './components/payment-driver/payment-driver.component';
import { BankDetailsComponent } from './components/bank-details/bank-details.component';
import {CardDetailsComponent} from './components/card-details/card-details.component' 
import { EditCardDetailsComponent } from './components/edit-card-details/edit-card-details.component';
import { RouteComponent } from './components/route/route.component';

const routes: Routes = [
  { path: '', component: LogInComponent },
  { path: 'log-in', component: LogInComponent },
  { path: 'new-user/:id', component: NewUserComponent },
  { path: 'new-driver/:id', component: NewDriverComponent },
  { path: 'exists-user/:id', component: ExistsUserComponent },
  { path: 'exists-driver', component: ExistsDriverComponent },
  { path: 'new-driver/:id', component: NewDriverComponent },
  { path: 'exists-passenger/:id', component: ExistsPassengerComponent },
  { path: 'new-traveling-d', component: NewTravelingDComponent },
  { path: 'new-traveling-p', component: NewTravelingPComponent },
  { path: 'exists-traveling-p', component: ExistsTravelingPComponent },
  { path: 'exists-traveling-d', component: ExistsTravelingDComponent },
  { path: 'details-traveling-p/:id', component: DetailsTravelingPComponent },
  { path: 'suitable-drivers/:id', component: SuitableDriversComponent },
  { path: 'confirm-driver', component: ConfirmDriverComponent },
  { path: 'confirm-passenger', component: ConfirmPassengerComponent },
  { path: 'map', component: MapComponent },
  { path: 'new', component: NewTravelingDComponent },
  { path: 'about', component: AboutComponent },
  { path: 'edit-user', component: EditUserComponent, canActivate: [Auth] },
  { path: 'edit-driver', component: EditDriverComponent },
  { path: 'googlemap', component: GoogleMapComponent } ,
  { path: 'statistics', component: StatisticsComponent } ,
  { path: 'delete-traveling-p/:id', component: DeleteTravelingPComponent },
  { path: 'delete-traveling-reg-p/:id', component: DeleteTravelingRegPComponent },
  { path: 'delete-traveling-d/:id', component: DeleteTravelingDComponent },
  { path: 'delete-traveling-reg-p/:id', component: DeleteTravelingRegDComponent },
  { path: 'paymentsP', component: PaymentPassengerComponent } ,
  { path: 'paymentsD', component: PaymentDriverComponent } ,
  { path: 'report/:id', component: ReportComponent } ,
  { path: 'bank-details', component: BankDetailsComponent } ,
  { path: 'card-details', component: CardDetailsComponent } ,
  { path: 'edit-card-details', component: EditCardDetailsComponent } ,
  { path: 'route/:id', component: RouteComponent }
 
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


