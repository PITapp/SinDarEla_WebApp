import { Component, Injector } from '@angular/core';
import { MeinBenutzerprofilGenerated } from './mein-benutzerprofil-generated.component';

@Component({
  selector: 'page-mein-benutzerprofil',
  templateUrl: './mein-benutzerprofil.component.html'
})
export class MeinBenutzerprofilComponent extends MeinBenutzerprofilGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
