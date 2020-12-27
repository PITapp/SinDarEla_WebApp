import { Component, Injector } from '@angular/core';
import { AuswertungenGenerated } from './auswertungen-generated.component';

@Component({
  selector: 'page-auswertungen',
  templateUrl: './auswertungen.component.html'
})
export class AuswertungenComponent extends AuswertungenGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
