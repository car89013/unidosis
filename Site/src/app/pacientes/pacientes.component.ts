import { Component, OnInit } from '@angular/core';
import {GridOptions} from 'ag-grid';
import {Pacientes} from '../models/pacientes';
import {PacientesService} from '../services/pacientes.service';

@Component({
  selector: 'app-pacientes',
  templateUrl: './pacientes.component.html',
  styleUrls: ['./pacientes.component.scss']
})
export class PacientesComponent implements OnInit {

  pacientesGrid: GridOptions;
  public actividad: number;
  public msgActividad: string;
  public paciente: Pacientes;
  public editando = true;

  constructor(private svrPacientes: PacientesService) {

    this.pacientesGrid = <GridOptions>{
      rowSelection: 'single',
      enableFilter: true,
      enableSorting: true,
      enableColResize: true
    };

    this.pacientesGrid.columnDefs = [
      { headerName: 'Afiliación', field: 'Afiliacion'},
      { headerName: 'Nombre', field: 'Nombre'},
      { headerName: 'Apellido Paterno', field: 'Paterno'},
      { headerName: 'Apellido Materno', field: 'Materno'},
      { headerName: 'Fecha Nacimiento', field: 'fecha_nacimiento'},
    ];

    this.svrPacientes.getAllPacientes().then( (a: Pacientes[]) => {
      console.log(a);
      this.pacientesGrid.rowData = a;
    });
  }

  ngOnInit() {
    this.actividad = 0;
    this.paciente = null;
  }

  public onGridReady(event: any) {}

  public onPacientesSelected(evento: any) {
    this.paciente = evento.api.getSelectedRows()[0];
  }

  public acteptarButton() {
    this.msgActividad = '';
    if (this.actividad === 1 ) {
      this.svrPacientes.setPaciente(this.paciente).then((a: any) => {
        this.svrPacientes.getAllPacientes().then((b: Pacientes[]) => {
          this.pacientesGrid.rowData = b;
          this.pacientesGrid.api.setRowData(this.pacientesGrid.rowData);
        });
      });
    } else  {
      this.svrPacientes.putPaciente(this.paciente).then((a: any) => {
        this.svrPacientes.getAllPacientes().then((b: Pacientes[]) => {
          this.pacientesGrid.rowData = b;
          this.pacientesGrid.api.setRowData(this.pacientesGrid.rowData);
        });
      });
    }
    this.limpiaVariables();
  }

  public cancelarButton() {
    this.limpiaVariables();
    this.svrPacientes.getAllPacientes().then((b: Pacientes[]) => {
      this.pacientesGrid.rowData = b;
      this.pacientesGrid.api.setRowData(this.pacientesGrid.rowData);
    });
  }

  public addButton() {
    this.actividad = 1;
    this.msgActividad = 'Alta de Paciente';
    this.paciente = new Pacientes();
    this.editando = false;
  }

  public editButton() {
    console.log(this.paciente);
    if (this.paciente !== null) {
      this.actividad = 2;
      this.msgActividad = 'Editar Paciente';
      this. editando = true;
    } else {
      alert('No ha seleccionado ningun registro');
    }
  }
  public limpiaVariables() {
    this.actividad = 0;
    this.msgActividad = '';
    this.paciente = null;
  }

}
