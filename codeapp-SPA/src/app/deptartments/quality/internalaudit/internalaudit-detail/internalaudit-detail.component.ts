import { Component, OnInit, ViewChild } from '@angular/core';
import { Audit } from 'src/app/_models/audit';
import { TabsetComponent } from 'ngx-bootstrap';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';
import { QualityService } from 'src/app/_services/quality.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-internalaudit-detail',
  templateUrl: './internalaudit-detail.component.html',
  styleUrls: ['./internalaudit-detail.component.css']
})
export class InternalauditDetailComponent implements OnInit {
  @ViewChild('auditTabs', { static: true }) auditTabs: TabsetComponent;
  audit: Audit;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private qualityService: QualityService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.audit = data['audit'];
    });

    this.route.queryParams.subscribe(params => {
      const selectedTab = params['tab'];
      this.auditTabs.tabs[selectedTab > 0 ? selectedTab : 0].active = true;
    });

  this.galleryOptions = [
    {
      width: '500px',
      height: '500px',
      imagePercent: 100,
      thumbnailsColumns: 4,
      imageAnimation: NgxGalleryAnimation.Slide,
      preview: false
    }

  ];
  this.galleryImages = this.getImages();
  }

  getImages() {
    const imageUrls = [];
    if (this.audit.photoaudits) {
    for (let i = 0; i < this.audit.photoaudits.length; i++) {
      imageUrls.push({
        small: this.audit.photoaudits[i].url,
        medium: this.audit.photoaudits[i].url,
        big: this.audit.photoaudits[i].url,
        description: this.audit.photoaudits[i].description
      });
    }
  }
    return imageUrls;
  }

  selectTab(tabId: number) {
    this.auditTabs.tabs[tabId].active = true;
  }

}
