import {
  Component,
  TemplateRef,
  OnInit,
  EventEmitter,
  Input,
  Output
} from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap';

@Component({
  selector: 'app-modal-service-confirm-window',
  templateUrl: './modal-service-confirm-window.component.html',
  styleUrls: ['./modal-service-confirm-window.component.css']
})
export class ModalServiceConfirmWindowComponent implements OnInit {
  @Input() modalRef: BsModalRef;
  @Output() deleteEvent = new EventEmitter();
  message: string;

  constructor(private modalService: BsModalService) {}

  ngOnInit() {}

  deleteItem() {
    this.deleteEvent.emit();
  }


  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.message = 'Confirmed!';
    this.modalRef.hide();
  }

  decline(): void {
    this.message = 'Declined!';
    this.modalRef.hide();
  }
}
