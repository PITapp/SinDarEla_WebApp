import { Component, Injector } from '@angular/core';
import { NachrichtenGenerated } from './nachrichten-generated.component';

@Component({
  selector: 'page-nachrichten',
  templateUrl: './nachrichten.component.html'
})
export class NachrichtenComponent extends NachrichtenGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
