import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../../services/api/client/Client.service'
//import { UpdateClientComponent } from '../update-client/update-client.component'

@Component({
  selector: 'app-display-client',
  templateUrl: './display-client.component.html',
  styleUrls: ['./display-client.component.scss']
})
export class DisplayClientComponent implements OnInit {

  clients: any;

  constructor(private clientServices:ClientService) { }

  ngOnInit(): void {
    this.clientServices.getAllClients().subscribe(data =>{
      console.log(data);
      this.clients=data;
    });
  }

  onDeleteClient(idToDelete:number){
    console.log("delete: "+idToDelete);
    let confirmDelete = this.clientServices.deleteClient(idToDelete);
  }

  onUpdateClient(idToUpdate:number){
    console.log("update: "+idToUpdate);

    //this.updateComponent.updateClient(formNewClient: ClientI,idToUpdate)
    //let confirmDelete = this.clientServices.deleteClient(idToUpdate);
  }
}
