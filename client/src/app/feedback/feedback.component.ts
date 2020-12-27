import { Component, Injector } from '@angular/core';
import { FeedbackGenerated } from './feedback-generated.component';

@Component({
  selector: 'page-feedback',
  templateUrl: './feedback.component.html'
})
export class FeedbackComponent extends FeedbackGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
