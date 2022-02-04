import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CreateClientComponent } from './create-client/create-client.component'
import { DisplayClientComponent } from './display-client/display-client.component'
//import { UpdateClientComponent } from './update-client/update-client.component'




const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Clientes'
    },
    children: [
      {
        path: 'registrar',
        component:CreateClientComponent,
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
        component:DisplayClientComponent,
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
        component:DisplayClientComponent,
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
export class ClientRoutingModule {}
