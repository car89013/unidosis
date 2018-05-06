import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';


import {AppComponent} from './app.component';
import {RouterModule, Routes} from '@angular/router';
import {PacientesComponent} from './pacientes/pacientes.component';
import {MedicosComponent} from './medicos/medicos.component';
import {AgGridModule} from 'ag-grid-angular';
import {MedicosService} from './services/medicos.service';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {EnfermerasComponent} from './enfermeras/enfermeras.component';
import {PacientesService} from './services/pacientes.service';
import {EnfermerasService} from './services/enfermeras.service';
import { SalasComponent } from './salas/salas.component';
import {SalasService} from './services/salas.service';
import {AtencionPacientesComponent} from './atencionpacientes/atencionpacientes.component';
import {MatButtonModule, MatTabsModule} from '@angular/material';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {IngresosService} from './services/ingresos.service';
import {ConfigService} from './services/config.service';

const appRouter: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full'  },
  { path: 'pacientes', component: PacientesComponent},
  { path: 'medicos', component: MedicosComponent},
  { path: 'enfermeras', component: EnfermerasComponent},
  { path: 'salas', component: SalasComponent},
  { path: 'atencionpacientes', component: AtencionPacientesComponent},

];

@NgModule({
  declarations: [
    AppComponent,
    PacientesComponent,
    MedicosComponent,
    EnfermerasComponent,
    SalasComponent,
    AtencionPacientesComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MDBBootstrapModule.forRoot(),
    RouterModule.forRoot(appRouter),
    AgGridModule.withComponents([]),
    BrowserAnimationsModule,
    MatTabsModule,
    MatButtonModule,
  ],
  providers: [MedicosService, PacientesService, EnfermerasService, SalasService,
  IngresosService, ConfigService],
  bootstrap: [AppComponent],
})
export class AppModule { }
