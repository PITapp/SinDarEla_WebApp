import { Component, Injector } from '@angular/core';
import { EinstellungenGenerated } from './einstellungen-generated.component';

@Component({
  selector: 'page-einstellungen',
  templateUrl: './einstellungen.component.html'
})
export class EinstellungenComponent extends EinstellungenGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
