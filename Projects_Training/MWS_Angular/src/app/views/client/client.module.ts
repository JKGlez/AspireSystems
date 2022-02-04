import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateClientComponent } from './create-client/create-client.component';
import { DisplayClientComponent } from './display-client/display-client.component';
//import { UpdateClientComponent } from './update-client/update-client.component';

// Client Routing
import { ClientRoutingModule } from './client-routing.module';


import { FormGroup, FormControl, Validators } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    CreateClientComponent,
    DisplayClientComponent,
    //UpdateClientComponent
  ],
  imports: [
    CommonModule,
    ClientRoutingModule,
    FormsModule,
    ReactiveFormsModule

  ]
})
export class ClientModule { }
