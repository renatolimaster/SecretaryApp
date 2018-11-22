import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SettingsService {
  currentLang: string;

  constructor() {
    this.currentLang = 'en';
  }

  setLanguage(lang: string) {
    this.currentLang = lang;
  }
  getLanguage() {
    return this.currentLang;
  }

}
