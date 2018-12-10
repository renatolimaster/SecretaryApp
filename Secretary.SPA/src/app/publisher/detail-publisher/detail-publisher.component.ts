import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PublisherService } from 'src/app/_services/publisher.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Publicador } from 'src/app/_models/Publicador';

@Component({
  selector: 'app-detail-publisher',
  templateUrl: './detail-publisher.component.html',
  styleUrls: ['./detail-publisher.component.css']
})
export class DetailPublisherComponent implements OnInit {
  title = 'Publisher';
  subTitles = 'Details';
  publisher: Publicador;
  del: any;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private publisherService: PublisherService,
    private alertifyService: AlertifyService
    ) { }

  ngOnInit() {
    this.catchParams();
    this.loadCongregation();
  }

  catchParams() {
    this.del = <boolean>this.route.snapshot.params['del'];
    if (this.del === 'true') {
      this.subTitles = 'Delete';
    } else {
      this.subTitles = 'Details';
    }
  }

  loadCongregation() {
    this.route.data.subscribe(data => {
      this.publisher = data['publisher'];
    });
  }

  deleteFieldService(id: number) {
    this.publisherService.deletePublisher(id).subscribe(
      () => {
        this.alertifyService.success('Publisher deleted successfully!');
        this.router.navigate(['/publisher']);
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

}
