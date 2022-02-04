import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CreateVehicleComponent } from './create-vehicle/create-vehicle.component';
import { DisplayVehicleComponent } from './display-vehicle/display-vehicle.component';
//import { UpdateClientComponent } from './update-client/update-client.component'




const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Vehiculos'
    },
    children: [
      {
        path: 'registrar',
        component: CreateVehicleComponent,
        data: {
          title: 'Registrar'
        }
      },
      {
        path: '',
        redirectTo: 'Mostrar'
      },
      {
        path: 'mostrar',
        component:DisplayVehicleComponent,
        data: {
          title: 'Mostrar'
        }
      },
      // {
      //   path: 'actualizar',
      //   component:UpdateClientComponent,
      //   data: {
      //     title: 'Actualizar'
      //   }
      // },
      {
        path: 'deudores',
        component:DisplayVehicleComponent,
        data: {
          title: 'Deudores'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VehicleRoutingModule {}
