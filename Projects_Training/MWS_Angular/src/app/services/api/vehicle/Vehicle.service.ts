import { Injectable } from "@angular/core";

import { HttpClient } from "@angular/common/http";
import { GlobalV } from "../../../shared/globalV";
import { Observable } from "rxjs";

import { Vehicle } from "../../../models/vehicle.model";

@Injectable({
  providedIn: "root",
})
export class VehicleService {
  public url: string = GlobalV.urlAPI;
  private approved: boolean = false;

  constructor(private http: HttpClient) {}

  getAllVehicle(): Observable<Vehicle[]> {
    let apiMethod = this.url + "Vehicles";
    return this.http.get<Vehicle[]>(apiMethod, {});
  }

  postNewVehicle(vehicle: Vehicle): any{
    console.log('Entrando a POST:');
    console.log(vehicle)
    let apiMethod = this.url+"Vehicles";
    let x = this.http.post<Vehicle>(apiMethod, vehicle ).subscribe(arg => {
      console.log('Posted');
      console.log(arg);
      this.approved = true;
    });
    return this.approved;
  }

  deleteVehicle(idVehicle: number): any {
    console.log("Entrando a DELETE:");
    let apiMethod = this.url + "Vehicles/";
    let x = this.http
      .delete<Vehicle>(apiMethod + idVehicle)
      .subscribe((arg) => {
        console.log("Detelted");
        console.log(arg);
        this.approved = true;
      });
    return this.approved;
  }
}
