import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { OrderItem } from '../models/orders-item.component';
import { ManagerItem } from '../models/manager-item';
import { ClientItem } from '../models/client-item';

 
@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private url = environment.apiUrl + 'api/orders/';

  constructor(private http: HttpClient) { }

  getOrders(): Observable<Array<OrderItem>> {
    return this.http.get<Array<OrderItem>>(this.url);
  }

  getOrder(orderid: number): Observable<OrderItem> {
    return this.http.get<OrderItem>(`${this.url}${orderid}`);
  }

  getManagers(): Observable<Array<ManagerItem>> {
    return this.http.get<Array<ManagerItem>>(environment.apiUrl + 'api/manager/');
  }

  getClients(): Observable<Array<ClientItem>> {
    return this.http.get<Array<ClientItem>>(environment.apiUrl + 'api/clients/');
  }

  addOrder(order: OrderItem): Observable<OrderItem> {
    return this.http.post<OrderItem>(`${this.url}`, order);
  }

  updateOrder(order: OrderItem): Observable<Object> {
    return this.http.put<Object>(`${this.url}${order.id}`, order);
  }

  deleteOrder(orderid: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${orderid}`);
  }
}
