import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateVehicleComponent } from './create-vehicle/create-vehicle.component';
import { DisplayVehicleComponent } from './display-vehicle/display-vehicle.component';

//vehicle routing
import { VehicleRoutingModule } from '../vehicles/vehicle-routing.module'


import { FormGroup, FormControl, Validators } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CreateVehicleComponent,
    DisplayVehicleComponent
  ],
  imports: [
    CommonModule,
    VehicleRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class VehiclesModule { }
