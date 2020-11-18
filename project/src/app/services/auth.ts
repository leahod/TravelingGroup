import { Injectable } from '@angular/core'
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class Auth implements CanActivate {

    resetLocalStorage = 1;
    changeUserLogin = 0;
    textUser = "";
    hiddenchangeUserLogin: boolean = true;
    deleteReg :number;
    delete:number;
    report:number;
    

    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        if (!JSON.parse(localStorage.getItem("user"))) {
            this.router.navigate(['/log-in']);
            return false;
        }
        return true;
    }
}