import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ManipulationFormComponent } from './manipulation-form/manipulation-form.component';

@NgModule({
  imports:      [ BrowserModule ],
    declarations: [AppComponent, ManipulationFormComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
