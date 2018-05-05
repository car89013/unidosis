import { Component, OnInit } from '@angular/core';
import {SalasService} from '../services/salas.service';
import {Salas} from '../models/salas';
import {Ingresos} from '../models/ingresos';
import {Camas} from '../models/camas';
import {IngresosService} from '../services/ingresos.service';
import {GridOptions} from 'ag-grid';
import {Asignacioncamas} from '../models/asignacioncamas';
import {Router, Routes} from '@angular/router';

@Component({
  selector: 'app-ingresos',
  templateUrl: './ingresos.component.html',
  styleUrls: ['./ingresos.component.scss']
})
export class IngresosComponent implements OnInit {
  ingresosGrid: GridOptions;
  ingresosHistoricosGrid: GridOptions;
  salas: Salas;
  salaSeleccionada: Salas;
  ingresos: Ingresos;
  ingresoSeleccionado: Ingresos;

  constructor(private svrSalas: SalasService, private  svrIngresos: IngresosService, private router: Router) {
    this.ingresosGrid = <GridOptions>{
      rowSelection: 'single',
      enableFilter: true,
      enableSorting: true,
      enableColResize: true,
    };

    this.ingresosGrid.columnDefs = [
      { headerName: 'Brazalete', field: 'num_brazalete'},
      { headerName: 'Fecha Ingreso', field: 'fecha_ingreso'},
      { headerName: 'Nombre', field: 'paciente.Nombre'},
      { headerName: 'Apellido Paterno', field: 'paciente.Paterno'},
      { headerName: 'Apellido Materno', field: 'paciente.Materno'},
      { headerName: 'Número Cama', field: 'asignacion.cama.desc_cama'},
    ];
    this.ingresosHistoricosGrid = <GridOptions>{
      rowSelection: 'single',
      enableFilter: true,
      enableSorting: true,
      enableColResize: true,
    };

    this.ingresosHistoricosGrid.columnDefs = [
      { headerName: 'Brazalete', field: 'num_brazalete'},
      { headerName: 'Fecha Ingreso', field: 'fecha_ingreso'},
      { headerName: 'Nombre', field: 'paciente.Nombre'},
      { headerName: 'Apellido Paterno', field: 'paciente.Paterno'},
      { headerName: 'Apellido Materno', field: 'paciente.Materno'},
      { headerName: 'Número Cama', field: 'asignacion.cama.desc_cama'},
    ];
    this.svrSalas.getAllSalas().then( (a: Salas) => {
      this.salas = a;
      console.log('Informacion obtenida: ', this.salas);
    });
  }

  ngOnInit() {
    this.ingresoSeleccionado = null;
  }

  onSelectSala(evento: any) {
    console.log(evento.srcElement.value);
    console.log(this.salaSeleccionada);
    this.svrIngresos.getIngresosBySalaId(evento.srcElement.value, true ).then((i: Ingresos[]) => {
      this.ingresosGrid.rowData = i;
      this.ingresosGrid.api.setRowData(this.ingresosGrid.rowData);
      this.ingresosGrid.api.sizeColumnsToFit();
    });
    this.svrIngresos.getIngresosBySalaId(evento.srcElement.value, false ).then((i: Ingresos[]) => {
      this.ingresosHistoricosGrid.rowData = i;
      this.ingresosHistoricosGrid.api.setRowData(this.ingresosHistoricosGrid.rowData);
    });
  }

  public onGridReady(event: any) {}

  public onIngresoSelected(evento: any) {
    this.ingresoSeleccionado = evento.api.getSelectedRows()[0];
  }

  clickAtencionPacientes() {
    if (this.ingresoSeleccionado != null) {
      this.svrIngresos.numBrazalete = this.ingresoSeleccionado.num_brazalete;
      this.router.navigate(['/atencionpacientes']);
    } else {
      alert('No a seleccionado ningun registro.');
    }
  }

}
