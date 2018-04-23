import { Component, OnInit } from '@angular/core';
import {GridOptions} from 'ag-grid';
import {Enfermeras} from '../models/enfermeras';
import {EnfermerasService} from '../services/enfermeras.service';
import {Medicos} from '../models/medicos';

@Component({
  selector: 'app-enfermeras',
  templateUrl: './enfermeras.component.html',
  styleUrls: ['./enfermeras.component.scss']
})
export class EnfermerasComponent implements OnInit {

  enfermerasGrid: GridOptions;
  public actividad: number;
  public msgActividad: string;
  public enfermera: Enfermeras;
  public editando = true;

  constructor(private svrEnfermeras: EnfermerasService) {

    this.enfermerasGrid = <GridOptions>{
      rowSelection: 'single',
      enableFilter: true,
      enableSorting: true,
      enableColResize: true
    };

    this.enfermerasGrid.columnDefs = [
      { headerName: 'Matricula', field: 'num_adscripcion'},
      { headerName: 'Nombre', field: 'Nombre'},
      { headerName: 'Apellido Paterno', field: 'Paterno'},
      { headerName: 'Apellido Materno', field: 'Materno'},
      { headerName: 'Cedula Prof', field: 'cedula_prof'},
    ];

    this.svrEnfermeras.getAllEnfermeras().then( (a: Enfermeras[]) => {
      console.log(a);
      this.enfermerasGrid.rowData = a;
    });
  }

  ngOnInit() {
    this.actividad = 0;
  }

  public onGridReady(event: any) {}

  public onEnfermerasSelected(evento: any) {
    this.enfermera = evento.api.getSelectedRows()[0];
  }

  public acteptarButton() {
    this.msgActividad = '';
    if (this.actividad === 1 ) {
      this.svrEnfermeras.setEnfermera(this.enfermera).then((a: any) => {
        this.svrEnfermeras.getAllEnfermeras().then((b: Medicos[]) => {
          this.enfermerasGrid.rowData = b;
          this.enfermerasGrid.api.setRowData(this.enfermerasGrid.rowData);
        });
      });
    } else  {
      this.svrEnfermeras.putEnfermera(this.enfermera).then((a: any) => {
        this.svrEnfermeras.getAllEnfermeras().then((b: Medicos[]) => {
          this.enfermerasGrid.rowData = b;
          this.enfermerasGrid.api.setRowData(this.enfermerasGrid.rowData);
        });
      });
    }
    this.limpiaVariables();
  }

  public cancelarButton() {
    this.limpiaVariables();
    this.svrEnfermeras.getAllEnfermeras().then((b: Medicos[]) => {
      this.enfermerasGrid.rowData = b;
      this.enfermerasGrid.api.setRowData(this.enfermerasGrid.rowData);
    });
  }

  public addButton() {
    this.actividad = 1;
    this.msgActividad = 'Alta de Enfermeras';
    this.enfermera = new Enfermeras();
    this.editando = false;
  }

  public editButton() {
    if (this.enfermera != null) {
      this.actividad = 2;
      this.msgActividad = 'Editar Enfermera';
      this. editando = true;
    } else {
      alert('No a seleccionado ningun registro para editar.');
    }
  }
  public limpiaVariables() {
    this.actividad = 0;
    this.msgActividad = '';
    this.enfermera = null;
  }

}
