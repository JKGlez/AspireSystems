import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  {
    title: true,
    name: 'Work Orders'
  },
  {
    name: 'Create a Work Order',
    url: '/ordenes/crear',
    icon: 'cil-plus'
  },
  {
    name: 'Display Work Orders',
    url: '/ordenes/mostrar',
    icon: 'fa fa-eye',
    children: [
      {
        name: 'All',
        url: '/ordenes/mostrar',
        icon: 'cil-folder-open'
      },
      {
        name: 'Working',
        url: '/ordenes/trabajando',
        icon: 'cil-garage'
      },
      {
        name: 'Without Paying',
        url: '/ordenes/pendientes-pago',
        icon: 'fa fa-usd'
      },
      {
        name: 'Archived',
        url: '/ordenes/archivadas',
        icon: 'fa fa-archive'
      }
    ]
  },
  {
    title: true,
    name: 'Clients'
  },
  {
    name: 'Register New Client',
    url: '/clientes/registrar',
    icon: 'cil-user-plus'
  },
  {
    name: 'Display Clients',
    url: '/clientes/mostrar',
    icon: 'cil-address-book',
    children: [
      {
        name: 'All Clients',
        url: '/clientes/mostrar',
        icon: 'cil-people'
      },
      {
        name: 'Debtors',
        url: '/clientes/deudores',
        icon: 'icon-pin'
      }

    ]
  },
  {
    title: true,
    name: 'Vehicles'
  },
  {
    name: 'Register new Vehicle',
    url: '/vehiculos/registrar',
    icon: 'fa fa-truck'
  },
  {
    name: 'Display Vehicles',
    url: '/vehiculos/mostrar',
    icon: 'fa fa-car',
    children: [
      {
        name: 'All Vehicles',
        url: '/vehiculos/mostrar',
        icon: 'fa fa-car'
      },
      {
        name: 'Empty Tag',
        url: '/vehiculos/empty',
        icon: 'icon-pin'
      }

    ]
  },
  {
    title: true,
    name: 'Extras',
  },
  {
    name: 'Pages',
    url: '/pages',
    icon: 'icon-star',
    children: [
      {
        name: 'Login',
        url: '/login',
        icon: 'icon-star'
      },
      {
        name: 'Register',
        url: '/register',
        icon: 'icon-star'
      },
      {
        name: 'Error 404',
        url: '/404',
        icon: 'icon-star'
      },
      {
        name: 'Error 500',
        url: '/500',
        icon: 'icon-star'
      }
    ]
  },

  {
    name: 'Disabled',
    url: '/dashboard',
    icon: 'icon-ban',
    badge: {
      variant: 'secondary',
      text: 'NEW'
    },
    attributes: { disabled: true },
  },
];
