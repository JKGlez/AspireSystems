import { Component, Inject, OnInit } from '@angular/core';
import { DOCUMENT } from "@angular/common";
import { getStyle, rgbToHex } from "@coreui/coreui/dist/js/coreui-utilities";
import { VehicleService } from '../../../services/api/vehicle/Vehicle.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { VehiclesModule } from '../vehicles.module';
import { Vehicle } from '../../../models/vehicle.model';

@Component({
  selector: 'app-create-vehicle',
  templateUrl: './create-vehicle.component.html',
  styleUrls: ['./create-vehicle.component.scss']
})
export class CreateVehicleComponent implements OnInit {

  msgStatus: boolean = false;
  msg: any = "MSG";

  constructor(
    @Inject(DOCUMENT) private _document: any,
    private vehicleServices: VehicleService
  ) {}

  public vehicle_create(): void {
    Array.from(this._document.querySelectorAll(".vehicle-create")).forEach(
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
    this.vehicle_create();
  }

  newVehicleForm = new FormGroup({
    Id_Vehicle: new FormControl("1", Validators.required),
    Brand_Vehicle: new FormControl("", Validators.required),
    Model_Vehicle: new FormControl("", Validators.required),
    NickName_Vehicle: new FormControl("", Validators.required),
    Owner_Vehicle: new FormControl("", Validators.required),
  });

  onCreateVehicle(formNewVehicle: Vehicle): any {
    console.log("Method at create-vehicle.component.ts V8:");
    let verifyRegister = this.vehicleServices.postNewVehicle(formNewVehicle);
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
