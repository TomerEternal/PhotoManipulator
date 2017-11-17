import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';

import { AppComponent } from './app.component';
import { ManipulationFormComponent } from './manipulation-form/manipulation-form.component';
import { ImageFormModel } from './shared/models/imageformmodel';

@NgModule({
  imports:      [ BrowserModule,FormsModule ],
  declarations: [AppComponent, ManipulationFormComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
