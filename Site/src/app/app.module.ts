import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';


import { AppComponent } from './app.component';
import {RouterModule, Routes} from '@angular/router';
import { PacientesComponent } from './pacientes/pacientes.component';

const appRouter: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full'  },
  { path: 'pacientes', component: PacientesComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    PacientesComponent
  ],
  imports: [
    BrowserModule,
    MDBBootstrapModule.forRoot(),
    RouterModule.forRoot(appRouter)
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
