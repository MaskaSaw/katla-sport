import { Component, OnInit } from '@angular/core';
import { HiveListItem } from '../models/hive-list-item';
import { HiveService } from '../services/hive.service';
import { HiveSectionListItem } from '../models/hive-section-list-item';

@Component({
  selector: 'app-hive-list',
  templateUrl: './hive-list.component.html',
  styleUrls: ['./hive-list.component.css']
})
export class HiveListComponent implements OnInit {

  hives: HiveListItem[];
  route: any;
  hiveId: any;
  hiveSections: HiveSectionListItem[];

  constructor(private hiveService: HiveService) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.hiveId = p['id'];
      this.hiveService.getHiveSections(this.hiveId).subscribe(s => this.hiveSections = s);
    })
  }

  getHives() {
    this.hiveService.getHives().subscribe(h => this.hives = h);
  }

  onDelete(hiveId: number) {
    var hive = this.hives.find(h => h.id == hiveId);
    this.hiveService.setHiveStatus(hiveId, true).subscribe(c => hive.isDeleted = true);
  }

  onRestore(hiveId: number) {
  }

  
}
