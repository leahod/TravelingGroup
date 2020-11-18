import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/entities/user';
import { UserServiceService } from 'src/app/services/user-service.service';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { Auth } from 'src/app/services/auth';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.scss']
})
export class NewUserComponent implements OnInit {

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  matcher = new MyErrorStateMatcher();
  formControl: any;

  id: number;
  public user: User = new User("", "", "", true,"","", null,"","");
  selectGender: 'female' | 'male' = 'male';// 'girl' | 'son' = 'son';

  constructor(
    private spinnerService: Ng4LoadingSpinnerService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private userServiceService: UserServiceService,
    private changeUser: Auth
  ) { }

  ngOnInit() {
    this.changeUser.hiddenchangeUserLogin = true;
    this.setUser();
  }

  setUser() {

    this.activatedRoute.url.subscribe(url => {
      this.id = +this.activatedRoute.snapshot.paramMap.get('id')
    });
    console.log(this.id);
    this.userServiceService.getUserById(this.id.toString()).subscribe
          (state =>{ this.user = state });
  }
  SaveDetails() {
    console.log(this.user);
    if (this.user.Name != null && this.user.Mail != null&&this.user.Name != "" && this.user.Mail != "") {
      this.user.Gender = this.selectGender == "male" ? false : true;
      
      localStorage.setItem("user", JSON.stringify(this.user));
      // this.spinnerService.show();
      
     
      this.router.navigate(['/card-details'])
    }
  }

}
