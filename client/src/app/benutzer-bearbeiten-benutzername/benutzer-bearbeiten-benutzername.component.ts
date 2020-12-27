import { Component, Injector } from '@angular/core';
import { BenutzerBearbeitenBenutzernameGenerated } from './benutzer-bearbeiten-benutzername-generated.component';

@Component({
  selector: 'page-benutzer-bearbeiten-benutzername',
  templateUrl: './benutzer-bearbeiten-benutzername.component.html'
})
export class BenutzerBearbeitenBenutzernameComponent extends BenutzerBearbeitenBenutzernameGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
