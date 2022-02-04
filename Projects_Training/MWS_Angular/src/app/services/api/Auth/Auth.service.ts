import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { GlobalV } from "../../../shared/globalV";

import { LoginI } from "../../../models/login.interface";
import { ResponseI } from "../../../models/response.interface";
import { promise } from "protractor";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  public TOKEN_NAME = "Token_Auth";
  public url: string = GlobalV.urlAPI;

  constructor(private http: HttpClient) {}

  get getToken(){
    return localStorage.getItem(this.TOKEN_NAME);
  }

  public loginByUsername(form: LoginI): any {

    let apiMethod = this.url + "Account";

    let approved: boolean = false;

    console.log("Enter AUTH v2");

    console.log(form);

    this.http.post<ResponseI>(apiMethod, form).subscribe((data) => {
      let dataResponse: ResponseI = data;
      console.log('Inside API CALL');
      console.log(dataResponse);
      if (dataResponse.UserRole != "Unauthorized") {
        console.log("INSIDE IF");
        localStorage.setItem(this.TOKEN_NAME, dataResponse.JwkToken);
        localStorage.setItem("UserName", dataResponse.UserToken);
        localStorage.setItem("UserRole", dataResponse.UserRole);
        console.log("ACCEPTED ON IF");
        approved = true;
      } else if (dataResponse.UserRole == "Unauthorized"){
        console.log("DENIED ON ELSE");
        approved =  false;
      }
    });

    console.log('Final auth ' + approved);

    return approved;
  }

}
