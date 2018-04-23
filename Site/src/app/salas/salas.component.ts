import { Component, OnInit } from '@angular/core';
import {GridOptions, RefreshCellsParams} from 'ag-grid';
import {Salas} from '../models/salas';
import {SalasService} from '../services/salas.service';
import {Camas} from '../models/camas';
import {componentRefresh} from '@angular/core/src/render3/instructions';

@Component({
  selector: 'app-salas',
  templateUrl: './salas.component.html',
  styleUrls: ['./salas.component.scss']
})
export class SalasComponent implements OnInit {

  salasGrid: GridOptions;
  dispGrid: GridOptions;
  noDispGrid: GridOptions;
  public actividad: number;
  public msgActividad: string;
  public salas: Salas;
  public camaDisponible: Camas;
  public camaAsignada: Camas;
  public editando = true;
  public camasDisponibles: Camas[];
  public camasAsignadas: Camas[];

  constructor(private svrSalas: SalasService) {

    this.salasGrid = <GridOptions>{
      rowSelection: 'single',
      enableFilter: true,
      enableSorting: true,
      enableColResize: true
    };
    this.dispGrid = <GridOptions>{
      rowSelection: 'single',
      enableFilter: true,
      enableSorting: true,
      enableColResize: true
    }
    this.noDispGrid = <GridOptions>{
      rowSelection: 'single',
      enableFilter: true,
      enableSorting: true,
      enableColResize: true
    }

    this.salasGrid.columnDefs = [
      { headerName: 'Id', field: 'id'},
      { headerName: 'Descripción', field: 'desc_sala'},
      { headerName: 'Número de camas', field: 'numeroCamas'},
    ];
    this.dispGrid.columnDefs = [
      { headerName: 'Id', field: 'id'},
      { headerName: 'Descripción', field: 'desc_cama'},
    ];
    this.noDispGrid.columnDefs = [
      { headerName: 'Id', field: 'id'},
      { headerName: 'Descripción', field: 'desc_cama'},
    ];

    this.svrSalas.getAllSalas().then( (a: Salas[]) => {
      this.salasGrid.rowData = a;
    });
  }


  ngOnInit() {
    this.actividad = 0;
  }

  public onGridReady(event: any) {}

  public onSalaSelected(evento: any) {
    this.salas = evento.api.getSelectedRows()[0];
  }
  public onCamaDisponibleSelected(evento: any) {
    this.camaDisponible = evento.api.getSelectedRows()[0];
  }
  public onCamaAsignadaSelected(evento: any) {
    this.camaAsignada = evento.api.getSelectedRows()[0];
  }

  public acteptarButton() {
    this.msgActividad = '';
    if (this.actividad === 1 ) {
      this.svrSalas.setSala(this.salas).then((a: any) => {
        this.svrSalas.getAllSalas().then((b: Salas[]) => {
          this.salasGrid.rowData = b;
        });
      });
    } else  {
      this.svrSalas.putSala(this.salas).then((a: any) => {
        this.svrSalas.getAllSalas().then((b: Salas[]) => {
          this.salasGrid.rowData = b;
        });
      });
    }
    this.actividad = 0;
    this.limpiaVariables();
  }

  public cancelarButton() {
    this.actividad = 0;
    this.msgActividad = '';
    this.limpiaVariables();
  }

  public addButton() {
    this.actividad = 1;
    this.msgActividad = 'Alta de Salas';
    this.salas = new Salas();
    this.editando = false;
    this.salas.id = 0;
    this.getDisponiblesyNoAsignadas();
  }

  public editButton() {
    this.actividad = 2;
    this.msgActividad = 'Editar Sala';
    this. editando = true;
    this.getDisponiblesyNoAsignadas();
  }
  public getDisponiblesyNoAsignadas() {
    console.log(this.salas.id);
    this.svrSalas.getCamasDisponibles(this.salas.id, true ).then((d: Camas[]) => {
      this.dispGrid.rowData = d;
    });
    this.svrSalas.getCamasDisponibles(this.salas.id, false ).then((nd: Camas[]) => {
      this.noDispGrid.rowData = nd;
    });
  }
  public agregarButton() {
    this.dispGrid.rowData.splice(this.dispGrid.rowData.lastIndexOf(this.camaDisponible), 1);
    this.noDispGrid.rowData.splice(this.noDispGrid.rowData.length, 0, this.camaDisponible);
    this.dispGrid.api.setRowData(this.dispGrid.rowData);
    this.noDispGrid.api.setRowData(this.noDispGrid.rowData);
  }
  public quitarButton() {
    this.noDispGrid.rowData.splice(this.noDispGrid.rowData.lastIndexOf(this.camaAsignada), 1);
    this.dispGrid.rowData.splice(this.dispGrid.rowData.length, 0, this.camaAsignada);
    this.dispGrid.api.setRowData(this.dispGrid.rowData);
    this.noDispGrid.api.setRowData(this.noDispGrid.rowData);
}
  public limpiaVariables() {
    this.camaAsignada = null;
    this.camaDisponible = null;
  }

}
