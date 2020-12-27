import { Component, Injector } from '@angular/core';
import { DatenschutzGenerated } from './datenschutz-generated.component';

@Component({
  selector: 'page-datenschutz',
  templateUrl: './datenschutz.component.html'
})
export class DatenschutzComponent extends DatenschutzGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
