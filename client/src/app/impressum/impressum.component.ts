import { Component, Injector } from '@angular/core';
import { ImpressumGenerated } from './impressum-generated.component';

@Component({
  selector: 'page-impressum',
  templateUrl: './impressum.component.html'
})
export class ImpressumComponent extends ImpressumGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
