import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule ,ReactiveFormsModule} from '@angular/forms';
import { NewDriverComponent } from './components/new-driver/new-driver.component';
import { NewUserComponent } from './components/new-user/new-user.component';
import { NewTravelingDComponent } from './components/new-traveling-d/new-traveling-d.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MaterialModule } from './material/material.module';
import { from } from 'rxjs';
import { ExistsDriverComponent } from './components/exists-driver/exists-driver.component';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';
import { MatIconModule } from '@angular/material/icon';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatTreeModule } from '@angular/material/tree';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { MatButtonModule } from '@angular/material/button';
import {MatExpansionModule} from '@angular/material/expansion';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ExistsUserComponent } from './components/exists-user/exists-user.component'
import { ExistsPassengerComponent } from './components/exists-passenger/exists-passenger.component';
import { AgmCoreModule } from '@agm/core';
import { AgmDirectionModule } from 'agm-direction';
import { NewTravelingPComponent } from './components/new-traveling-p/new-traveling-p.component';
import { MapComponent } from './components/map/map.component';
import {MatStepperModule} from '@angular/material/stepper';
import {GooglePlaceModule} from 'ngx-google-places-autocomplete'
import {NgxLoadingModule, ngxLoadingAnimationTypes} from 'ngx-loading';
import { ExistsTravelingPComponent } from './components/exists-traveling-p/exists-traveling-p.component';
import { ExistsTravelingDComponent } from './components/exists-traveling-d/exists-traveling-d.component';
import { DetailsTravelingPComponent } from './components/details-traveling-p/details-traveling-p.component';
import { SuitableDriversComponent } from './components/suitable-drivers/suitable-drivers.component';
import { ConfirmDriverComponent } from './components/confirm-driver/confirm-driver.component';
import { ConfirmPassengerComponent } from './components/confirm-passenger/confirm-passenger.component';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';
import { AboutComponent } from './components/about/about.component';
import { EditUserComponent } from './components/edit-user/edit-user.component';
import { EditDriverComponent } from './components/edit-driver/edit-driver.component';
import { TravelingRangeComponent } from './components/traveling-range/traveling-range.component';
import { FooterComponent } from './components/footer/footer.component';
import { GoogleMapComponent } from './components/google-map/google-map.component';
import {DirectionsMapDirective} from '../app/components/directions-map.directive';
import { SideNavComponent } from './components/side-nav/side-nav.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import { StatisticsComponent } from './components/statistics/statistics.component';
import { ChartsModule } from 'ng2-charts';
import { DeleteTravelingPComponent } from './components/delete-traveling-p/delete-traveling-p.component';
import { DeleteTravelingDComponent } from './components/delete-traveling-d/delete-traveling-d.component';
import { DeleteTravelingRegPComponent } from './components/delete-traveling-reg-p/delete-traveling-reg-p.component';
import { PaymentPassengerComponent } from './components/payment-passenger/payment-passenger.component';
import { DeleteTravelingRegDComponent } from './components/delete-traveling-reg-d/delete-traveling-reg-d.component';
import { PaymentDriverComponent } from './components/payment-driver/payment-driver.component';
import { ReportComponent } from './components/report/report.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatTabsModule} from '@angular/material/tabs';
import { BankDetailsComponent } from './components/bank-details/bank-details.component';
import { CardDetailsComponent } from './components/card-details/card-details.component';
import { EditCardDetailsComponent } from './components/edit-card-details/edit-card-details.component';
import { RouteComponent } from './components/route/route.component';
// import { TelInputComponent } from './components/tel-input/tel-input.component';

@NgModule({
  entryComponents: [DeleteTravelingDComponent,DeleteTravelingPComponent],
  declarations: [
    AppComponent,
    LogInComponent,
    NewDriverComponent,
    NewUserComponent,
    NewTravelingDComponent,
    NewTravelingPComponent,
    ExistsDriverComponent,
    NavbarComponent,
    ExistsUserComponent,
    ExistsPassengerComponent,
    MapComponent,
    ExistsTravelingPComponent,
    ExistsTravelingDComponent,
    DetailsTravelingPComponent,
    SuitableDriversComponent,
    ConfirmDriverComponent,
    ConfirmPassengerComponent,
    AboutComponent,
    EditUserComponent,
    EditDriverComponent,
    TravelingRangeComponent,
    FooterComponent,
    GoogleMapComponent,
    DirectionsMapDirective,
    SideNavComponent,
    StatisticsComponent,
    DeleteTravelingPComponent,
    DeleteTravelingDComponent,
    DeleteTravelingRegPComponent,
    PaymentPassengerComponent,
    DeleteTravelingRegDComponent,
    PaymentDriverComponent,
    ReportComponent,
    BankDetailsComponent,
    CardDetailsComponent,
    EditCardDetailsComponent,
    RouteComponent,
    // TelInputComponent
    
  ],
  imports: [
    // MDBBootstrapModule.forRoot(),
    Ng4LoadingSpinnerModule.forRoot(),
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ChartsModule,
    MaterialModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatCheckboxModule,
    MatRadioModule,
    MatIconModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatTreeModule,
    MatFormFieldModule,
    MatInputModule,
    MatStepperModule,
    NgxMaterialTimepickerModule,
    MatExpansionModule,
    GooglePlaceModule,
    MatSidenavModule,
    MatDialogModule,
    MatTabsModule,
   
    NgxLoadingModule.forRoot({
      animationType: ngxLoadingAnimationTypes.threeBounce,
      backdropBackgroundColour: 'rgba(0,0,0,0)', 
      backdropBorderRadius: '0.01px',
      primaryColour: 'green', 
      secondaryColour: 'green', 
      tertiaryColour: 'green'
    }),
    AgmCoreModule.forRoot(  {
      apiKey: 'AIzaSyD7Wui1ikC-x4CMLYBpPz-8Yutf2l3glNo',
     libraries: ["places"]
    }),
    // AgmCoreModule.forRoot({
    //   apiKey:'AIzaSyCn2QLkFec04RcpweqjPDoSuYkZwuYeZ2I'
    // }),
    AgmDirectionModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
