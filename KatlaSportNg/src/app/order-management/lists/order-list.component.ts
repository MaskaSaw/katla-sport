import { Component, OnInit } from '@angular/core';
import { OrderItem } from '../models/orders-item.component';
import { OrderService } from '../services/order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {

  orders: OrderItem[];

  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.getOrders();
  }

  getOrders() {
    this.orderService.getOrders().subscribe(h => this.orders = h);
  }

  onDelete(orderId: number) {
    this.orderService.deleteOrder(orderId).subscribe(p => this.getOrders());   
  }
}
