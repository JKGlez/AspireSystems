import { Component, OnInit } from "@angular/core";
import { VehicleService } from "../../../services/api/vehicle/Vehicle.service";
import { VehiclesModule } from "../vehicles.module";

@Component({
  selector: "app-display-vehicle",
  templateUrl: "./display-vehicle.component.html",
  styleUrls: ["./display-vehicle.component.scss"],
})
export class DisplayVehicleComponent implements OnInit {

  vehicles: any;

  constructor(private vehicleServices: VehicleService) {}

  ngOnInit(): void {
    this.vehicleServices.getAllVehicle().subscribe((data) => {
      console.log(data);
      this.vehicles = data;
    });
  }

  onDeleteVehicle(idToDelete:number){
    console.log("delete: "+idToDelete);
    let confirmDelete = this.vehicleServices.deleteVehicle(idToDelete);
  }
}
