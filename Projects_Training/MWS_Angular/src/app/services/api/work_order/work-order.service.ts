import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WorkOrder } from '../../../models/work_order.model';
import { GlobalV } from '../../../shared/globalV';

@Injectable({
  providedIn: 'root'
})
export class WorkOrderService {

  public url : string = GlobalV.urlAPI;
  private approved: boolean = false;

  constructor(private http:HttpClient) { }

  getAllWorkOrders():Observable<WorkOrder[]>{
    console.log("getAllWorkOrders(V2):");
    let apiMethod = this.url+"WorkOrders";
    return this.http.get<WorkOrder[]>(apiMethod, {});
  }

}
