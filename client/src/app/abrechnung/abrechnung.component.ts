import { Component, Injector } from '@angular/core';
import { AbrechnungGenerated } from './abrechnung-generated.component';

@Component({
  selector: 'page-abrechnung',
  templateUrl: './abrechnung.component.html'
})
export class AbrechnungComponent extends AbrechnungGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
