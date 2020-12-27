import { Component, Injector } from '@angular/core';
import { BenutzerNeuGenerated } from './benutzer-neu-generated.component';

@Component({
  selector: 'page-benutzer-neu',
  templateUrl: './benutzer-neu.component.html'
})
export class BenutzerNeuComponent extends BenutzerNeuGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
