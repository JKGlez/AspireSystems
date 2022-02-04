import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DisplayWorkorderComponent } from './display-workorder/display-workorder.component'
import { CreateWorkorderComponent } from './create-workorder/create-workorder.component'




const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Ordenes'
    },
    children: [
      {
        path: 'crear',
        component:CreateWorkorderComponent,
        data: {
          title: 'Crear'
        }
      },
      {
        path: '',
        redirectTo: 'Mostrar'
      },
      {
        path: 'mostrar',
        component:DisplayWorkorderComponent,
        data: {
          title: 'Mostrar'
        }
      },
      {
        path: 'trabajando',
        component:DisplayWorkorderComponent,
        data: {
          title: 'Trabajando'
        }
      },
      {
        path: 'pendientes-pago',
        component:DisplayWorkorderComponent,
        data: {
          title: 'Pendientes Pago'
        }
      },
      {
        path: 'archivadas',
        component:DisplayWorkorderComponent,
        data: {
          title: 'Archivadas'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkorderRoutingModule {}
