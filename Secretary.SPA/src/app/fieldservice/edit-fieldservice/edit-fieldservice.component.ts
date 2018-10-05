import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { ServicoCampo } from '../../_models/ServicoCampo';
import { ReportService } from '../../_services/report.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';
import { CongregationService } from '../../_services/congregation.service';
import { Congregacao } from '../../_models/Congregacao';
import { PioneerService } from '../../_services/pioneer.service';
import { Pioneiro } from '../../_models/Pioneiro';
import { NgForm } from '@angular/forms';
import { AuthService } from '../../_services/auth.service';
import { Publicador } from '../../_models/Publicador';
import { PublisherService } from '../../_services/publisher.service';

@Component({
  selector: 'app-edit-fieldservice',
  templateUrl: './edit-fieldservice.component.html',
  styleUrls: ['./edit-fieldservice.component.css']
})
export class EditFieldserviceComponent implements OnInit {
  @ViewChild('editForm')
  editForm: NgForm;
  title = 'Field Service';
  subTitles = 'Edit';
  report: ServicoCampo;
  congregations: Congregacao[] = [];
  pioneers: Pioneiro[] = [];
  publishers: Publicador[];
  selectedCongregation: number;
  selectedPioneer: number;
  selectedPublisher: number;
  publisherName: string;

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(
    private authService: AuthService,
    private publisherService: PublisherService,
    private pioneerService: PioneerService,
    private congregationService: CongregationService,
    private reportService: ReportService,
    private route: ActivatedRoute,
    private alertifyService: AlertifyService
  ) {}

  ngOnInit() {
    this.loadCongregations();
    this.loadPioneers();
    this.loadPublishers();
    this.loadReport();
  }

  compareCongregationFn(c1: Congregacao, c2: Congregacao): boolean {
    return c1 && c2 ? c1.id === c2.id : c1 === c2;
  }

  comparePioneerFn(c1: Pioneiro, c2: Pioneiro): boolean {
    return c1 && c2 ? c1.id === c2.id : c1 === c2;
  }

  comparePublisherFn(c1: Publicador, c2: Publicador): boolean {
    return c1 && c2 ? c1.id === c2.id : c1 === c2;
  }

  loadReport() {
    console.log('edit loadReport()');
    this.route.data.subscribe(data => {
      this.report = data['report'];
      this.selectedCongregation = this.report.congregacao.id;
      this.selectedPioneer = this.report.pioneiro.id;
      this.selectedPublisher = this.report.publicador.id;
      this.report.dataReferencia = new Date(this.report.dataReferencia);
      this.report.dataEntrega = new Date(this.report.dataEntrega);
      this.publisherName = this.report.publicador.nome;
      this.report.pioneiroId = this.report.pioneiro.id;
      this.report.congregacaoId = this.report.congregacao.id;
      this.report.publicadorId = this.report.publicador.id;
      console.log('pioneiro: ' + this.report.pioneiroId + ' - ' + this.report.congregacaoId + ' - ' + this.report.publicadorId);
    });
    // this.reportService.getReport(this.route.snapshot.params['id']).subscribe(
    //   (report: ServicoCampo) => {
    //     this.report = report;
    //     this.selectedCongregation = this.report.congregacao.id;
    //     this.selectedPioneer = this.report.pioneiro.id;
    //     this.report.dataReferencia = new Date(this.report.dataReferencia);
    //     this.report.dataEntrega = new Date(this.report.dataEntrega);
    //     this.publisherName = this.report.publicador.nome;
    //   },
    //   error => {
    //     this.alertifyService.error(error);
    //   }
    // );
  }

  // TODO: Remove this when we're done
  get diagnostic() {
    return JSON.stringify(this.report);
  }

  loadCongregations() {
    this.congregationService.getCongregations().subscribe(
      (congregations: Congregacao[] = []) => {
        this.congregations = congregations;
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  loadPioneers() {
    this.pioneerService.getPioneers().subscribe(
      (pioneers: Pioneiro[]) => {
        this.pioneers = pioneers;
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  loadPublishers() {
    console.log('loadPublishers');
    this.publisherService.getPublishers().subscribe(
      (publishers: Publicador[]) => {
        this.publishers = publishers;
        this.publishers.forEach(element => {
          console.log('publicador: ' + element.id + ' - ' + element.nome);
        });
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  updateFieldService(report: ServicoCampo) {
    // report = this.report;
    // this.reportService
    //   .updateReport(this.authService.decodedToken.nameid, report)
    //   .subscribe(
    //     next => {
    //       this.alertifyService.success('Report updated successfully!');
    //       this.editForm.resetForm(report);
    //     },
    //     error => {
    //       this.alertifyService.error(error);
    //     }
    //   );
    console.log('dataEntrega: ' + report.dataEntrega + ' - dataReferencia: ' + report.dataReferencia);
      this.reportService
      .updateReport(report.id, report)
      .subscribe(
        next => {
          this.alertifyService.success('Report updated successfully!');
          this.editForm.resetForm(report);
        },
        error => {
          this.alertifyService.error(error);
        }
      );
  }
}
