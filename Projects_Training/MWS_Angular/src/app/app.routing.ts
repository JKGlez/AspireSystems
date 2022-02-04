import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Import Containers
import { DefaultLayoutComponent } from './containers';

// Import Base compoments
import { P404Component } from './views/error/404.component';
import { P500Component } from './views/error/500.component';
import { LoginComponent } from './views/login/login.component';
import { RegisterComponent } from './views/register/register.component';

// Import AuthGuard functionality
import { AuthGuard } from './services/guards/auth.guard';
import { RoleGuard } from './services/guards/role.guard';

export const routes: Routes = [
  {
    path: '',
    //redirectTo: 'dashboard',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  {
    path: 'dashboard',
    redirectTo: 'dashboard',
    pathMatch: 'full',

  },
  {
    path: '404',
    component: P404Component,
    data: {
      title: 'Page 404'
    }
  },
  {
    path: '500',
    component: P500Component,
    data: {
      title: 'Page 500'
    }
  },
  {
    path: 'login',
    component: LoginComponent,
    data: {
      title: 'Login Page'
    }
  },
  {
    path: 'register',
    component: RegisterComponent,
    data: {
      title: 'Register Page'
    }
  },
  {
    path: '',
    canActivate : [AuthGuard, RoleGuard],
    component: DefaultLayoutComponent,
    data: {
      title: 'Home',
      expectedRoles : ['Administrator','Employee']
    },
    children: [
      {
        path: 'dashboard',
        loadChildren: () => import('./views/dashboard/dashboard.module').then(m => m.DashboardModule)
      },
      {
        path: 'ordenes',
        loadChildren: () => import('./views/workorder/workorder.module').then(m => m.WorkOrderModule)
      },
      {
        path: 'clientes',
        loadChildren: () => import('./views/client/client.module').then(m => m.ClientModule)
      },
      {
        path: 'vehiculos',
        loadChildren: () => import('./views/vehicles/vehicles.module').then(m => m.VehiclesModule)
      },
    ]
  },
  { path: '**', component: P404Component }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' }) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
