import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { GlobalV } from '../../../shared/globalV';
import { Observable } from 'rxjs';
import { Client } from '../../../models/client.model';
import { ClientI } from '../../../models/client.interface';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  public url : string = GlobalV.urlAPI;
  private approved: boolean = false;

  constructor(private http:HttpClient) { }

  getAllClients():Observable<Client[]>{
    console.log("getAllClients(V2):");
    let apiMethod = this.url+"Clients";
    return this.http.get<Client[]>(apiMethod, {});
  }

  postNewClient(client: ClientI): any{
    console.log('Entrando a POST:');
    console.log(client)
    let apiMethod = this.url+"Clients";
    let x = this.http.post<ClientI>(apiMethod, client ).subscribe(arg => {
      console.log('Posted');
      console.log(arg);
      this.approved = true;
    });
    return this.approved;
  }

  deleteClient(idClient: number): any{
    console.log('Entrando a DELETE:');
    let apiMethod = this.url+"Clients/";
    let x = this.http.delete<ClientI>(apiMethod + idClient ).subscribe(arg => {
      console.log('Detelted');
      console.log(arg);
      this.approved = true;
    });
    return this.approved;
  }
}
