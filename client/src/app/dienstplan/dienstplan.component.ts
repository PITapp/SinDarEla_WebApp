import { Component, Injector } from '@angular/core';
import { DienstplanGenerated } from './dienstplan-generated.component';

@Component({
  selector: 'page-dienstplan',
  templateUrl: './dienstplan.component.html'
})
export class DienstplanComponent extends DienstplanGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
