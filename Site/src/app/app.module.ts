import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';


import { AppComponent } from './app.component';
import {RouterModule, Routes} from '@angular/router';
import { PacientesComponent } from './pacientes/pacientes.component';
import { MedicosComponent } from './medicos/medicos.component';
import {AgGridModule} from 'ag-grid-angular';
import {MedicosService} from './services/medicos.service';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

const appRouter: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full'  },
  { path: 'pacientes', component: PacientesComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    PacientesComponent,
    MedicosComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MDBBootstrapModule.forRoot(),
    RouterModule.forRoot(appRouter),
    AgGridModule.withComponents([]),
  ],
  providers: [MedicosService],
  bootstrap: [AppComponent],
})
export class AppModule { }
