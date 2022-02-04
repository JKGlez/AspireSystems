import { Component, Inject, OnInit } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { getStyle, rgbToHex } from '@coreui/coreui/dist/js/coreui-utilities';
import { WorkOrderService } from '../../../services/api/work_order/work-order.service';

@Component({
  selector: 'app-display-workorder',
  templateUrl: './display-workorder.component.html',
  styleUrls: ['./display-workorder.component.scss']
})

export class DisplayWorkorderComponent implements OnInit {

  title:string = 'Ordenes de trabajo';
  workorders: any;

  constructor(@Inject(DOCUMENT) private _document: any,private workorderServices: WorkOrderService) {}

  public workorder_display(): void {
    Array.from(this._document.querySelectorAll('.workorder-display')).forEach((el: HTMLElement) => {
      const background = getStyle('background-color', el);
      const table = this._document.createElement('table');
      table.innerHTML = `
        <table class="w-100">
          <tr>
            <td class="text-muted">HEX:</td>
            <td class="font-weight-bold">${rgbToHex(background)}</td>
          </tr>
          <tr>
            <td class="text-muted">RGB:</td>
            <td class="font-weight-bold">${background}</td>
          </tr>
        </table>
      `;
      el.parentNode.appendChild(table);
    });
  }




  // ngOnInit(): void {
  //   this.workorder_display();
  // }

  ngOnInit(): void {
    this.workorderServices.getAllWorkOrders().subscribe(data =>{
      console.log(data);
      this.workorders=data;
    });
  }

}


