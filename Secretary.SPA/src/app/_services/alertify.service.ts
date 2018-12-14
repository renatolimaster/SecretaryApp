import { Injectable } from '@angular/core';
// makes alertify globaly variable
declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {
  constructor() {}

  confirm(message: string, okCallback: () => any) {
    alertify.confirm(message, function (e: any) {
      if (e) {
        okCallback();
      } else {
        alertify.success('No');
      }
    });
  }

  alert(message: string) {
    alertify.alert(message);
  }

  success(message: string) {
    alertify.success(message);
  }

  error(message: string) {
    alertify.error(message);
  }

  warning(message: string) {
    alertify.warning(message);
  }

  message(message: string) {
    alertify.message(message);
  }
}
