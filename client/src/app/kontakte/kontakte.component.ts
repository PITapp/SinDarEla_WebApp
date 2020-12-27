import { Component, Injector } from '@angular/core';
import { KontakteGenerated } from './kontakte-generated.component';

@Component({
  selector: 'page-kontakte',
  templateUrl: './kontakte.component.html'
})
export class KontakteComponent extends KontakteGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
