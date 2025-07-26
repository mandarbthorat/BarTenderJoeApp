import { Directive, ElementRef, HostListener, OnInit } from '@angular/core';

@Directive({
  selector: '[fascetTracer]'
})
export class FascetTracerDirective implements OnInit {

  constructor(private el: ElementRef) {}

  ngOnInit(): void {
    this.log('Fascet tracer initialized.');
  }

  private log(message: string): void {
    const now = new Date();
    const timestamp = now.toLocaleTimeString();
    const existing = this.el.nativeElement.value;
    this.el.nativeElement.value = `${existing}\n${timestamp} - ${message}`.trim();
    this.el.nativeElement.scrollTop = this.el.nativeElement.scrollHeight;
  }

  @HostListener('document:click', ['$event'])
  handleClickEvent(event: Event): void {
    const target = event.target as HTMLElement;
    if (target.tagName === 'BUTTON') {
      const label = target.textContent?.trim() ?? 'Unnamed Button';
      this.log(`[BUTTON] - "${label}" button has been clicked`);
    }
  }

  @HostListener('document:keydown', ['$event'])
  handleKeydownEvent(event: KeyboardEvent): void {
    this.log(`[KEYPRS] - "${event.key}" key pressed.`);
  }
}
