import { Component, OnInit, ViewChild } from '@angular/core';
import { ServicoCampo } from '../../_models/ServicoCampo';
import { ReportService } from '../../_services/report.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';
import { CongregationService } from '../../_services/congregation.service';
import { Congregacao } from '../../_models/Congregacao';
import { PioneerService } from '../../_services/pioneer.service';
import { Pioneiro } from '../../_models/Pioneiro';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-edit-fieldservice',
  templateUrl: './edit-fieldservice.component.html',
  styleUrls: ['./edit-fieldservice.component.css']
})
export class EditFieldserviceComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  title = 'Field Service';
  subTitles = 'Edit';
  report: ServicoCampo;
  congregations: Congregacao[] = [];
  pioneers: Pioneiro[] = [];
  selectedCongregation: number;
  selectedPioneer: number;
  publisherName: string;

  constructor(
    private pioneerService: PioneerService,
    private congregationService: CongregationService,
    private reportService: ReportService,
    private route: ActivatedRoute,
    private alertifyService: AlertifyService
  ) {}

  ngOnInit() {
    this.loadCongregations();
    this.loadPioneers();
    this.loadReport();
  }

  compareCongregationFn(c1: Congregacao, c2: Congregacao): boolean {
    return c1 && c2 ? c1.id === c2.id : c1 === c2;
  }

  comparePioneerFn(c1: Pioneiro, c2: Pioneiro): boolean {
    return c1 && c2 ? c1.id === c2.id : c1 === c2;
  }

  loadReport() {
    this.reportService.getReport(this.route.snapshot.params['id']).subscribe(
      (report: ServicoCampo) => {
        this.report = report;
        this.selectedCongregation = this.report.congregacao.id;
        this.selectedPioneer = this.report.pioneiro.id;
        this.report.dataReferencia = new Date(this.report.dataReferencia);
        this.report.dataEntrega = new Date(this.report.dataEntrega);
        this.publisherName = this.report.publicador.nome;
      },
      error => {
        this.alertifyService.error(error);
      }
    );
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

  updateFieldService(report: ServicoCampo) {
    this.alertifyService.success('Report updated successfully!');
    this.editForm.resetForm(report);
  }
}
