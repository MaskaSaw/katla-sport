import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionService } from '../services/hive-section.service';
import { HiveSection } from '../models/hive-section';

@Component({
  selector: 'app-hive-section-form',
  templateUrl: './hive-section-form.component.html',
  styleUrls: ['./hive-section-form.component.css']
})
export class HiveSectionFormComponent implements OnInit {

  hiveId : number;
  hiveSection = new HiveSection(0, "", "", 0 ,false, "");
  existed = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hiveSectionService: HiveSectionService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      if (p["id"] === undefined) {
        this.hiveSection.storeHiveId = p['store-hive-id'];
        return;
      }
      this.hiveSectionService.getHiveSection(p["id"]).subscribe(h => {
        this.hiveSection = h;
        this.hiveSection.storeHiveId = p['store-hive-id'];
        console.log(p);
      });
      this.existed = true;
    });
  }

  navigateToSections() {
    if (this.hiveId === undefined)
    {
    this.hiveId = this.hiveSection.storeHiveId;
    }
    this.router.navigate([`/hive/${this.hiveId}/sections`]);
    }

  onCancel() {
    this.navigateToSections();
  }
  
  onSubmit() {
    if (this.existed) {
      this.hiveSectionService.updateHiveSection(this.hiveSection).subscribe(c => this.navigateToSections());
    } else {
      this.hiveSectionService.addHiveSection(this.hiveSection).subscribe(c => this.navigateToSections());
    }
  }

  onDelete() {
    this.hiveSectionService.setHiveSectionStatus(this.hiveSection.id, true).subscribe(c => this.hiveSection.isDeleted = true);
  }

  onUndelete() {
    this.hiveSectionService.setHiveSectionStatus(this.hiveSection.id, false).subscribe(c => this.hiveSection.isDeleted = false);
    console.log(this.hiveSection);
  }

  onPurge() {
    this.hiveSectionService.deleteHiveSection(this.hiveSection.id).subscribe(p => this.navigateToSections());
  }
}
