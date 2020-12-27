import { Component, Injector } from '@angular/core';
import { BenutzerBearbeitenGenerated } from './benutzer-bearbeiten-generated.component';

@Component({
  selector: 'page-benutzer-bearbeiten',
  templateUrl: './benutzer-bearbeiten.component.html'
})
export class BenutzerBearbeitenComponent extends BenutzerBearbeitenGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
