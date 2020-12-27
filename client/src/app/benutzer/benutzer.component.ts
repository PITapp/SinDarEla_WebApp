import { Component, Injector } from '@angular/core';
import { BenutzerGenerated } from './benutzer-generated.component';

@Component({
  selector: 'page-benutzer',
  templateUrl: './benutzer.component.html'
})
export class BenutzerComponent extends BenutzerGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
