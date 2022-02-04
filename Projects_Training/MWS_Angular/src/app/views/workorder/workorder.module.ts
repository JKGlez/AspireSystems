// Angular
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { DisplayWorkorderComponent } from './display-workorder/display-workorder.component'
import { CreateWorkorderComponent } from './create-workorder/create-workorder.component'

// Workorder Routing
import { WorkorderRoutingModule } from './workorder-routing.module';

@NgModule({
  imports: [
    CommonModule,
    WorkorderRoutingModule
  ],
  declarations: [
    DisplayWorkorderComponent,
    CreateWorkorderComponent
  ]
})
export class WorkOrderModule {
  type: string = '';
 }
