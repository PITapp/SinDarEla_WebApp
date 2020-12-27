import { Component, Injector } from '@angular/core';
import { MitarbeiterGenerated } from './mitarbeiter-generated.component';

@Component({
  selector: 'page-mitarbeiter',
  templateUrl: './mitarbeiter.component.html'
})
export class MitarbeiterComponent extends MitarbeiterGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
