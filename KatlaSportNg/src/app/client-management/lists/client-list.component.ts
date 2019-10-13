import { Component, OnInit } from '@angular/core';
import { ClientItem } from '../models/client-item';
import { ClientService } from '../services/client-service';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {

  clients: ClientItem[];

  constructor(private clientService: ClientService) { }

  ngOnInit() {
    this.getClients();
  }

  getClients() {
    this.clientService.getClients().subscribe(h => this.clients = h);
  }

  onDelete(clientId: number) {
    this.clientService.deleteClient(clientId).subscribe(p => this.getClients());   
  }
}
