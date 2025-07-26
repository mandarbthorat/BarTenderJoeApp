import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BartenderJoeComponent } from './components/bartender-joe/bartender-joe.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FascetTracerDirective } from './shared/fascet-tracer.directive';

@NgModule({
  declarations: [
    AppComponent,
    BartenderJoeComponent,
    FascetTracerDirective
  ],
  imports: [
    BrowserModule, FormsModule, HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
