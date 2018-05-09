import { Component, OnInit } from '@angular/core';
import {GridOptions} from 'ag-grid';
import {IngresosService} from '../services/ingresos.service';
import {BitacoraPacientes} from '../models/bitacora-pacientes';
import {Pacientes} from '../models/pacientes';
import {Asignacioncamas} from '../models/asignacioncamas';
import {Ingresos} from '../models/ingresos';
import {Salas} from '../models/salas';
import {Camas} from '../models/camas';
import {MatDialog} from '@angular/material';
import {PrescripcionComponent} from './prescripcion/prescripcion.component';
import {AplicacionComponent} from './aplicacion/aplicacion.component';

@Component({
  selector: 'app-prescipcion',
  templateUrl: './atencionpacientes.component.html',
  styleUrls: ['./atencionpacientes.component.scss']
})
export class AtencionPacientesComponent implements OnInit {

  bitacroraGrid: GridOptions;
  editando: true;
  brazalete: string;
  infoPaciente: Ingresos;

  constructor(public presDialog: MatDialog, private svratencion: IngresosService) {

    /* Inicializando infomraicón del paciente */
    this.infoPaciente = new Ingresos();
    this.infoPaciente.paciente = new Pacientes();
    this.infoPaciente.bitacora = [];
    this.infoPaciente.asignacion = new Asignacioncamas();
    this.infoPaciente.asignacion.sala = new Salas();
    this.infoPaciente.asignacion.cama = new Camas();
  }

  ngOnInit() {
    if ((this.svratencion.numBrazalete  != null) && (this.svratencion.numBrazalete !== undefined)) {
      this.brazalete = this.svratencion.numBrazalete;

      this.findbrazalete();
    } else {
      this.brazalete = '';
    }
  }

  public findbrazalete() {
    console.log('Brazalete ingresado: ', this.brazalete);
    if (this.brazalete.length > 0) {
      this.svratencion.getInfoPacieteByBrazaleteId(this.brazalete).then( (a: Ingresos) => {
        this.infoPaciente = a;
        console.log('Inofrmación obtenida: ', this.infoPaciente);
      });
    }
  }

  public showPrescripcionDialgo() {
    this.presDialog.open(PrescripcionComponent);
  }

  public showAplicacionDialgo() {
    this.svratencion.numBrazalete = this.brazalete;
    this.presDialog.open(AplicacionComponent);
  }

}
