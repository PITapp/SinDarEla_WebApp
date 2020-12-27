import { Component, Injector } from '@angular/core';
import { DokumenteGenerated } from './dokumente-generated.component';

@Component({
  selector: 'page-dokumente',
  templateUrl: './dokumente.component.html'
})
export class DokumenteComponent extends DokumenteGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
