import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { PasticceriaComponent } from './pasticceria/pasticceria.component';
import { PasticceriaFormComponent } from './pasticceria/pasticceria-form/pasticceria-form.component';
import { DolciComponent } from './dolci/dolci.component';
import { DolciFormComponent } from './dolci/dolci-form/dolci-form.component';

@NgModule({
  declarations: [
    AppComponent,
    PasticceriaComponent,
    PasticceriaFormComponent,
    DolciComponent,
    DolciFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
