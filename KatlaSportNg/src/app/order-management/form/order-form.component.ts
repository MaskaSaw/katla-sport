import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderService } from '../services/order.service';
import { OrderItem } from '../models/orders-item.component';
import { ManagerItem } from '../models/manager-item';
import { ClientItem } from '../models/client-item';


@Component({
  selector: 'app-order-form',
  templateUrl: './order-form.component.html',
  styleUrls: ['./order-form.component.css']
})
export class OrderFormComponent implements OnInit {

  order = new OrderItem(0, 0, 0);
  existed = false;
  managersList: ManagerItem[];
  clientslist: ClientItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private orderService: OrderService

  ) { }

  ngOnInit() {
    this.orderService.getManagers().subscribe(c => this.managersList = c);
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.orderService.getOrder(p['id']).subscribe(h => this.order = h);
      this.existed = true;
    });
    this.orderService.getClients().subscribe(c => this.clientslist = c);
    console.log(this.clientslist);
  }

  navigateToManagers() {
    this.router.navigate(['/orders']);
  }

  onCancel() {
    this.navigateToManagers();
  }
  
  onSubmit() {
    if (this.existed) {
      this.orderService.updateOrder(this.order).subscribe(c => this.navigateToManagers());
    } else {
      this.orderService.addOrder(this.order).subscribe(c => this.navigateToManagers());
    }
  }
}
