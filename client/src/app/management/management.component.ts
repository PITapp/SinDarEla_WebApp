import { Component, Injector } from '@angular/core';
import { ManagementGenerated } from './management-generated.component';

@Component({
  selector: 'page-management',
  templateUrl: './management.component.html'
})
export class ManagementComponent extends ManagementGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
