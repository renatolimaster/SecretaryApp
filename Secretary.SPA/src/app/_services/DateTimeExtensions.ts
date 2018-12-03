import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DateTimeExtensions {
  value: Date;

  constructor() {}

  FirstDayOfMonth(value: Date) {
    return new Date(value.getFullYear(), value.getMonth(), 1);
  }

  LastDayOfMonth(value: Date) {
    return new Date(value.getFullYear(), value.getMonth() + 1, 0);
  }

  CreateDate(day: number, months: number, years: number) {
    const date = new Date();
    date.setDate(day);
    date.setMonth(months);
    date.setFullYear(years);
    return date;
  }

  FirstServiceMonth(value: Date) {
    const date = new Date();
    const month = value.getMonth();
    const year = value.getFullYear();

    if (month > 8) {
      date.setDate(1);
      date.setMonth(8);
      date.setFullYear(year);
    } else {
      date.setDate(1);
      date.setMonth(8);
      date.setFullYear(year - 1);
    }

    return date;
  }
}
