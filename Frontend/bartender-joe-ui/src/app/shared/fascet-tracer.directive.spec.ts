import { FascetTracerDirective } from './fascet-tracer.directive';
import { ElementRef } from '@angular/core';

describe('FascetTracerDirective', () => {
  let textarea: HTMLTextAreaElement;
  let elementRef: ElementRef;
  let directive: FascetTracerDirective;

  beforeEach(() => {
    textarea = document.createElement('textarea');
    elementRef = new ElementRef(textarea);
    directive = new FascetTracerDirective(elementRef);
  });

  it('should create an instance', () => {
    expect(directive).toBeTruthy();
  });

  it('should append a log message', () => {
    // Call log method (using bracket notation to access private method for test)
    (directive as any).log('Test message');
    expect(textarea.value).toContain('Test message');
  });

  it('should log button clicks', () => {
    const button = document.createElement('button');
    button.textContent = 'Mix Drink';
    const event = new MouseEvent('click', { bubbles: true });
    Object.defineProperty(event, 'target', { value: button });
    directive.handleClickEvent(event);
    expect(textarea.value).toContain('[BUTTON] - "Mix Drink" button has been clicked');
  });

  it('should log key presses', () => {
    const event = new KeyboardEvent('keydown', { key: 'x' });
    directive.handleKeydownEvent(event);
    expect(textarea.value).toContain('[KEYPRS] - "x" key pressed.');
  });
});
