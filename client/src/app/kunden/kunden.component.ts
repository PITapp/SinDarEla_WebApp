import { Component, Injector } from '@angular/core';
import { KundenGenerated } from './kunden-generated.component';

@Component({
  selector: 'page-kunden',
  templateUrl: './kunden.component.html'
})
export class KundenComponent extends KundenGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
