import { Injectable } from "@angular/core";
import {
  ActivatedRouteSnapshot,
  CanActivate,
  RouterStateSnapshot,
  UrlTree,
} from "@angular/router";
import { Observable } from "rxjs";
import { LoginI } from "../../models/login.interface";
import { ResponseI } from "../../models/response.interface";
import { AuthService } from "../api/Auth/Auth.service";

@Injectable({
  providedIn: "root",
})
export class AuthGuard implements CanActivate {
  private authService: AuthService;

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {


    return true;
  }

  public verifyAuthentication(form: LoginI): boolean {
    let validUser: boolean = false;
    // this.api.loginByUsername(form).subscribe((data) => {
    //   let dataResponse: ResponseI = data;
    //   console.log(dataResponse);
    //   if (dataResponse.UserRole != "Unauthorized") {
    //     //localStorage.setItem("Token", dataResponse.JwkToken);
    //     //localStorage.setItem("UserName", dataResponse.UserToken);
    //     //localStorage.setItem("UserRole", dataResponse.UserRole);
    //     //this.router.navigate(['dashboard']);
    //     console.log("ACEPTADO");
    //     validUser = true;
    //   } else if (dataResponse.UserRole == "Unauthorized") {
    //     //this.errorStatus = true;
    //     console.log("DENEGADO");
    //     //console.log(this.errorMsg);
    //     validUser = false;
    //   }
    //   else{
    //     validUser = false;
    //   }
    // });
  return validUser;
  }
}
