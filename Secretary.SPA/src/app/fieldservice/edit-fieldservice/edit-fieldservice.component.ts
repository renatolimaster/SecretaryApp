import {
  Component,
  OnInit,
  ViewChild,
  HostListener,
  ChangeDetectorRef,
  Input
} from '@angular/core';
import { ServicoCampo } from '../../_models/ServicoCampo';
import { ReportService } from '../../_services/report.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';
import { CongregationService } from '../../_services/congregation.service';
import { Congregacao } from '../../_models/Congregacao';
import { PioneerService } from '../../_services/pioneer.service';
import { Pioneiro } from '../../_models/Pioneiro';
import { NgForm } from '@angular/forms';
import { Publicador } from '../../_models/Publicador';
import { PublisherService } from '../../_services/publisher.service';

import { BsModalRef } from 'ngx-bootstrap';

@Component({
  selector: 'app-edit-fieldservice',
  templateUrl: './edit-fieldservice.component.html',
  styleUrls: ['./edit-fieldservice.component.css']
})
export class EditFieldserviceComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  @Input() modalRef: BsModalRef;
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
  situacaoServicoCampo: string;

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(
    private cdRef: ChangeDetectorRef,
    private publisherService: PublisherService,
    private pioneerService: PioneerService,
    private congregationService: CongregationService,
    private reportService: ReportService,
    private route: ActivatedRoute,
    private alertifyService: AlertifyService
  ) {}

  ngOnInit() {
    this.selectedPioneer = 0;
    this.selectedCongregation = 0;
    this.selectedPublisher = 0;
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
      this.selectedCongregation = this.report.congregacaoId;
      this.selectedPioneer = this.report.pioneiro.id;
      this.selectedPublisher = this.report.publicador.id;
      this.report.dataReferencia = new Date(this.report.dataReferencia);
      this.report.dataEntrega = new Date(this.report.dataEntrega);
      this.publisherName = this.report.publicador.nome;
      this.report.pioneiroId = this.report.pioneiro.id;
      this.report.congregacaoId = this.report.congregacao.id;
      this.report.publicadorId = this.report.publicador.id;
      this.situacaoServicoCampo = this.report.publicador.situacaoServicoCampo;
    });
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
    this.publisherService.getPublishers().subscribe(
      (publishers: Publicador[]) => {
        this.publishers = publishers;
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  updateFieldService(report: ServicoCampo) {
    let totalHours = 0;
    totalHours = report.horas + report.horasBetel + report.creditoHoras;

    if (report.horas < 70) {
      if (totalHours > 70) {
        alert('Hours + Bethel + Credit = ' + totalHours + 'h and exceeds 70h, please adjust it!');
        return false;
      }
    }

    if (totalHours >= 30 && report.pioneiroId === 1) {
      if (!confirm('Are you sure to update that report just as publisher with ' +
        totalHours + ' of hours?')) {
        this.alertifyService.warning('Update canceled!');
        return false;
      }
    }

    this.reportService.updateReport(report.id, report).subscribe(
      () => {
        this.getReport(report.id);
        this.alertifyService.success('Report updated successfully!');
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }

  getReport(id: number) {
    this.reportService.getReport(id).subscribe(
      (reports: ServicoCampo) => {
        this.report = reports;
        this.selectedCongregation = this.report.congregacao.id;
        this.selectedPioneer = this.report.pioneiroId;
        this.selectedPublisher = this.report.publicador.id;
        this.report.dataReferencia = new Date(this.report.dataReferencia);
        this.report.dataEntrega = new Date(this.report.dataEntrega);
        this.publisherName = this.report.publicador.nome;
        this.report.pioneiroId = this.report.pioneiro.id;
        this.report.congregacaoId = this.report.congregacao.id;
        this.report.publicadorId = this.report.publicador.id;
        this.situacaoServicoCampo = this.report.publicador.situacaoServicoCampo;
        this.cdRef.detectChanges();
        this.editForm.control.markAsUntouched();
        this.editForm.control.markAsPristine();
      },
      error => {
        this.alertifyService.error(error);
      }
    );
    console.log('status: ' + this.editForm.dirty);
  }

  deleteAqui() {
    console.log('deleteAqui');
  }

  clickMethod(name: string) {
    if (confirm('Are you sure to delete ' + name)) {
      console.log('Implement delete functionality here');
    }
  }

}
