import { Component, OnInit } from '@angular/core';
import { ManagerItem } from '../models/manager-item';
import { ManagerService } from '../services/manager.service';

@Component({
  selector: 'app-manager-list',
  templateUrl: './manager-list.component.html',
  styleUrls: ['./manager-list.component.css']
})
export class ManagerListComponent implements OnInit {

  managers: ManagerItem[];

  constructor(private managerService: ManagerService) { }

  ngOnInit() {
    this.getManagers();
  }

  getManagers() {
    this.managerService.getManagers().subscribe(h => this.managers = h);
  }

  onDelete(managerId: number) {
    this.managerService.deleteManager(managerId).subscribe(p => this.getManagers());   
  }
}
