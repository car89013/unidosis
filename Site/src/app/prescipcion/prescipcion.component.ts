import { Component, OnInit } from '@angular/core';
import {GridOptions} from 'ag-grid';
import {IngresosService} from '../services/ingresos.service';
import {AtencionPacientes} from '../models/atencion-pacientes';
import {BitacoraPacientes} from '../models/bitacora-pacientes';
import {Pacientes} from '../models/pacientes';
import {Asignacioncamas} from '../models/asignacioncamas';

@Component({
  selector: 'app-prescipcion',
  templateUrl: './prescipcion.component.html',
  styleUrls: ['./prescipcion.component.scss']
})
export class PrescipcionComponent implements OnInit {

  bitacroraGrid: GridOptions;
  editando: true;
  brazalete: string;
  infoPaciente: AtencionPacientes;

  constructor(private svratencion: IngresosService) {

    /* Inicializando infomraicón del paciente */
    this.infoPaciente = new AtencionPacientes();
    this.infoPaciente.paciente = new Pacientes();
    this.infoPaciente.bitacora = [];
    this.infoPaciente.asignacion = new Asignacioncamas();

  }

  ngOnInit() {
  }

  public findbrazalete() {
    console.log('Brazalete ingresado: ', this.brazalete);
    if (this.brazalete.length > 0) {
      this.svratencion.getInfoPacieteByBrazaleteId(this.brazalete).then( (a: AtencionPacientes) => {
        this.infoPaciente = a;
        console.log('Inofrmación obtenida: ', this.infoPaciente);
      });
    }
  }

}
