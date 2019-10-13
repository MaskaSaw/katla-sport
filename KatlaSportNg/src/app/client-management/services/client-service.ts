import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { ClientItem } from '../models/client-item';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private url = environment.apiUrl + 'api/clients/';

  constructor(private http: HttpClient) { }

  getClients(): Observable<Array<ClientItem>> {
    return this.http.get<Array<ClientItem>>(this.url);
  }

  getClient(clientid: number): Observable<ClientItem> {
    return this.http.get<ClientItem>(`${this.url}${clientid}`);
  }

  addClient(client: ClientItem): Observable<ClientItem> {
    return this.http.post<ClientItem>(`${this.url}`, client);
  }

  updateClient(client: ClientItem): Observable<Object> {
    return this.http.put<Object>(`${this.url}${client.id}`, client);
  }

  deleteClient(clientid: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${clientid}`);
  }
}
