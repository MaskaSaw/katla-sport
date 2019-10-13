import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from '../services/client-service';
import { ClientItem } from '../models/client-item';

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {

  client = new ClientItem(0, "", "", "");
  existed = false;
  clientslist: ClientItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clientService: ClientService

  ) { }

  ngOnInit() {
    this.clientService.getClients().subscribe(c => this.clientslist = c);
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.clientService.getClient(p['id']).subscribe(h => this.client = h);
      this.existed = true;
    });
  }

  navigateToClients() {
    this.router.navigate(['/clients']);
  }

  onCancel() {
    this.navigateToClients();
  }
  
  onSubmit() {
    if (this.existed) {
      this.clientService.updateClient(this.client).subscribe(c => this.navigateToClients());
    } else {
      this.clientService.addClient(this.client).subscribe(c => this.navigateToClients());
    }
  }
}
