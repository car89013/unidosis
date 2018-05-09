import { Component, OnInit } from '@angular/core';
import {GridOptions} from 'ag-grid';
import {MatDialogRef} from '@angular/material';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {IngresosService} from '../../services/ingresos.service';

@Component({
  selector: 'app-prescripcion',
  templateUrl: './prescripcion.component.html',
  styleUrls: ['./prescripcion.component.scss']
})
export class PrescripcionComponent implements OnInit {

  detllaePreGrid: GridOptions;
  prescripcionFormGroup: FormGroup;
  numPrescrip: string;

  constructor(private svrIngreso: IngresosService, private dlgref: MatDialogRef<PrescripcionComponent>) {
    this.detllaePreGrid = <GridOptions>{
      rowSelection: 'single',
      enableFilter: true,
      enableSorting: true,
      enableColResize: true
    };

    this.detllaePreGrid.columnDefs = [
      { headerName: 'Gpo.', field: 'num_adscripcion', width: 80},
      { headerName: 'Gen', field: 'Nombre', width: 80},
      { headerName: 'Esp', field: 'Paterno', width: 80},
      { headerName: 'Dif', field: 'Materno', width: 80},
      { headerName: 'Descripción', field: 'cedula_prof'},
      { headerName: 'Nota', field: 'especialidad'},
      { headerName: 'Cant.', field: 'cant', width: 80},
      { headerName: 'Frec.', field: 'frec', width: 80},
    ];

    this.detllaePreGrid.rowData = [];
  }

  ngOnInit() {
    this.numPrescrip = this.svrIngreso.numPrescripcion;
    this.prescripcionFormGroup = new FormGroup( {
      gpo: new FormControl('010', [Validators.required]),
      gen: new FormControl( '000', [Validators.required]),
      esp: new FormControl('', [Validators.required]),
      dif: new FormControl('', [Validators.required]),
      nota: new FormControl('', [Validators.required]),
      cant: new FormControl('0', [Validators.required, Validators.min(1)]),
      frec: new FormControl('-1', [Validators.required, Validators.min(-1)]),
    });
  }

  public onGridReady(event: any) {
    this.detllaePreGrid.api.sizeColumnsToFit();
  }

  public cancelarButton() {
    this.dlgref.close();
  }
}
