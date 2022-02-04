import { Component, Inject, OnInit } from "@angular/core";
import { DOCUMENT } from "@angular/common";
import { getStyle, rgbToHex } from "@coreui/coreui/dist/js/coreui-utilities";

import { ClientI } from "../../../models/client.interface";

import { Client } from "../../../models/client.model";

import { FormGroup, FormControl, Validators } from "@angular/forms";

import { ClientService } from "../../../services/api/client/Client.service";

import { FormsModule, ReactiveFormsModule } from "@angular/forms";

@Component({
  selector: "app-create-client",
  templateUrl: "./create-client.component.html",
  styleUrls: ["./create-client.component.scss"],
})
export class CreateClientComponent implements OnInit {
  msgStatus: boolean = false;
  msg: any = "MSG";

  constructor(
    @Inject(DOCUMENT) private _document: any,
    private clientServices: ClientService
  ) {}

  public client_create(): void {
    Array.from(this._document.querySelectorAll(".client-create")).forEach(
      (el: HTMLElement) => {
        const background = getStyle("background-color", el);
        const table = this._document.createElement("table");
        table.innerHTML = `
        <table class="w-100">
          <tr>
            <td class="text-muted">HEX:</td>
            <td class="font-weight-bold">${rgbToHex(background)}</td>
          </tr>
          <tr>
            <td class="text-muted">RGB:</td>
            <td class="font-weight-bold">${background}</td>
          </tr>
        </table>
      `;
        el.parentNode.appendChild(table);
      }
    );
  }

  ngOnInit(): void {
    this.client_create();
  }

  newClientForm = new FormGroup({
    Id_Client: new FormControl("1", Validators.required),
    Name_Client: new FormControl("", Validators.required),
    NickName_Client: new FormControl("", Validators.required),
    Mobile_Phone_Client: new FormControl("", Validators.required),
    Email_Client: new FormControl("", Validators.required),
    Pay_Day_Client: new FormControl("", Validators.required),
    Billing_Data_Client: new FormControl("", Validators.required),
  });

  onCreateClient(formNewClient: ClientI): any {
    let payDay = "2022-01-18T16:15:33.8006215-06:00";
    console.log("Method at create-client.component.ts V8:");
    formNewClient.Billing_Data_Client = payDay;
    let verifyRegister = this.clientServices.postNewClient(formNewClient);
    console.log("create-client.ts");
    console.log(verifyRegister);

    //debugger
    if (verifyRegister) {
      this.msg = "Successfully Registered";
      this.msgStatus = true;
    } else {
      this.msg = "Invalid input, Check data"
      this.msgStatus = true;
    }
  }
}
