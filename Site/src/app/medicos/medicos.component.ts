import { Component, OnInit } from '@angular/core';
import {GridOptions} from 'ag-grid';
import {Medicos} from '../models/medicos';
import {MedicosService} from '../services/medicos.service';

@Component({
  selector: 'app-medicos',
  templateUrl: './medicos.component.html',
  styleUrls: ['./medicos.component.scss']
})
export class MedicosComponent implements OnInit {

  medicosGrid: GridOptions;
  public actividad: number;
  public msgActividad: string;
  public medico: Medicos;
  public editando = true;

  constructor(private svrMedicos: MedicosService) {

    this.medicosGrid = <GridOptions>{
      rowSelection: 'single',
      enableFilter: true,
      enableSorting: true,
      enableColResize: true
    };

    this.medicosGrid.columnDefs = [
      { headerName: 'Matricula', field: 'num_adscripcion'},
      { headerName: 'Nombre', field: 'Nombre'},
      { headerName: 'Apellido Paterno', field: 'Paterno'},
      { headerName: 'Apellido Materno', field: 'Materno'},
      { headerName: 'Cedula Prof', field: 'cedula_prof'},
      { headerName: 'Especialidad', field: 'especialidad'},
    ];

    this.svrMedicos.getAllMedicos().then( (a: Medicos[]) => {
      console.log(a);
      this.medicosGrid.rowData = a;
    });
  }

  ngOnInit() {
    this.limpiaVariables();
  }

  public onGridReady(event: any) {}

  public onMedicosSelected(evento: any) {
    this.medico = evento.api.getSelectedRows()[0];
  }

  public acteptarButton() {
    this.msgActividad = '';
    if (this.actividad === 1 ) {
      this.svrMedicos.setMedico(this.medico).then((a: any) => {
        this.svrMedicos.getAllMedicos().then((b: Medicos[]) => {
          this.medicosGrid.rowData = b;
          this.medicosGrid.api.setRowData(this.medicosGrid.rowData);
        });
      });
    } else  {
      this.svrMedicos.putMedico(this.medico).then((a: any) => {
        this.svrMedicos.getAllMedicos().then((b: Medicos[]) => {
          this.medicosGrid.rowData = b;
          this.medicosGrid.api.setRowData(this.medicosGrid.rowData);
        });
      });
    }
    this.limpiaVariables();
  }

  public cancelarButton() {
    this.limpiaVariables();
    this.svrMedicos.getAllMedicos().then((b: Medicos[]) => {
      this.medicosGrid.rowData = b;
      this.medicosGrid.api.setRowData(this.medicosGrid.rowData);
    });
  }

  public addButton() {
    this.actividad = 1;
    this.msgActividad = 'Alta de Doctores';
    this.medico = new Medicos();
    this.editando = false;
  }

  public editButton() {
    if (this.medico !== null) {
      this.actividad = 2;
      this.msgActividad = 'Editar Doctor';
      this. editando = true;
    } else {
      alert('No a seleccionado ningun registro para editar.');
    }
  }
  public limpiaVariables() {
    this.actividad = 0;
    this.msgActividad = '';
    this.medico = null;
  }
}
