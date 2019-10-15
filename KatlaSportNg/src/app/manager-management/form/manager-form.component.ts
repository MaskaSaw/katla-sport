import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ManagerService } from '../services/manager.service';
import { ManagerFormItem } from '../models/manager-form-item';
import { ManagerItem } from '../models/manager-item'

@Component({
  selector: 'app-manager-form',
  templateUrl: './manager-form.component.html',
  styleUrls: ['./manager-form.component.css']
})
export class ManagerFormComponent implements OnInit {

  file: File = null;
  manager = new ManagerItem(0, "", "", 0, 0, "");
  existed = false;
  managerslist: ManagerItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private managerService: ManagerService

  ) { }

  ngOnInit() {
    this.managerService.getManagers().subscribe(c => this.managerslist = c);
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.managerService.getManager(p['id']).subscribe(h => this.manager = h);
      this.existed = true;
    });
  }

  onFileChange(event) {
      this.file = event.target.files[0];
      console.log(this.file);
  }

  navigateToManagers() {
    this.router.navigate(['/managers']);
  }

  onCancel() {
    this.navigateToManagers();
  }
  
  onSubmit() {
    if (this.existed) {
      this.managerService.updateManager(this.manager, this.file).subscribe(c => this.navigateToManagers());
    } else {
      this.managerService.addManager(this.manager, this.file).subscribe(c => this.navigateToManagers());
    }
  }
}
