import { Component, OnInit, ViewChild } from '@angular/core';
import { ServicoCampo } from '../../_models/ServicoCampo';
import { ReportService } from '../../_services/report.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';
import { CongregationService } from '../../_services/congregation.service';
import { Congregacao } from '../../_models/Congregacao';
import { PioneerService } from '../../_services/pioneer.service';
import { Pioneiro } from '../../_models/Pioneiro';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
  NgForm
} from '@angular/forms';

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
  congregations: Congregacao[];
  pioneers: Pioneiro[];
  selectedCongregation: number;
  selectedPioneer: number;
  // model: any = {};
  // model: ServicoCampo;

  // myForm: FormGroup;

  constructor(
    // private fb: FormBuilder,
    private pioneerService: PioneerService,
    private congregationService: CongregationService,
    private reportService: ReportService,
    private route: ActivatedRoute,
    private alertifyService: AlertifyService
  ) {}

  ngOnInit() {
    // this.initForm();
    this.loadReport();
    this.loadCongregations();
    this.loadPioneers();
  }

  compareCongregationFn(c1: Congregacao, c2: Congregacao): boolean {
    return c1 && c2 ? c1.id === c2.id : c1 === c2;
  }

  comparePioneerFn(c1: Pioneiro, c2: Pioneiro): boolean {
    return c1 && c2 ? c1.id === c2.id : c1 === c2;
  }

  /*
  initForm() {
    this.myForm = this.fb.group({
      nome: ['', [Validators.required]],
      dataReferencia: ['', [Validators.required]],
      dataEntrega: ['', [Validators.required]],
      congregacao: ['', [Validators.required]],
      publicador: ['', [Validators.required]],
      pioneiro: ['', [Validators.required]],
      publicacoes: ['0', [Validators.required]],
      videosMostrados: ['0', [Validators.required]],
      horas: ['0', [Validators.required]],
      revisitas: ['0', [Validators.required]],
      estudos: ['0', [Validators.required]],
      horasBetel: ['0', [Validators.required]],
      creditoHoras: ['0', [Validators.required]],
      minutos: ['0', [Validators.required]]
    });
  }
*/
  loadReport() {
    this.reportService.getReport(this.route.snapshot.params['id']).subscribe(
      (report: ServicoCampo) => {
        this.report = report;
        this.selectedCongregation = this.report.congregacao.id;
        console.log('selectedCongregation: ' + this.selectedCongregation);
        this.selectedPioneer = this.report.pioneiro.id;
        console.log('pioneiro: ' + this.report.pioneiro.id);
        this.report.dataReferencia = new Date(this.report.dataReferencia);
        this.report.dataEntrega = new Date(this.report.dataEntrega);
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
      (congregations: Congregacao[]) => {
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

  updateFieldService() {
    console.log(this.report);
    this.alertifyService.success('Field service updated successfully!');
    this.selectedCongregation = this.report.congregacao.id;
    console.log('selectedCongregation: ' + this.selectedCongregation);
    this.selectedPioneer = this.report.pioneiro.id;
    console.log('pioneiro: ' + this.report.pioneiro.id);
    this.report.dataReferencia = new Date(this.report.dataReferencia);
    this.report.dataEntrega = new Date(this.report.dataEntrega);
    this.editForm.reset(this.report);
  }
}
