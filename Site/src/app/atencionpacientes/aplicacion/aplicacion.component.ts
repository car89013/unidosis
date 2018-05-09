import { Component, OnInit } from '@angular/core';
import {MatDialogRef} from '@angular/material';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {IngresosService} from '../../services/ingresos.service';

@Component({
  selector: 'app-aplicacion',
  templateUrl: './aplicacion.component.html',
  styleUrls: ['./aplicacion.component.scss']
})
export class AplicacionComponent implements OnInit {

  formGroup: FormGroup;
  correlacionado: boolean;

  constructor( private dlgref: MatDialogRef<AplicacionComponent>, private svrIngresos: IngresosService) { }

  ngOnInit() {
    this.formGroup = new FormGroup ({
      brazalete: new FormControl(this.svrIngresos.numBrazalete, [Validators.required]),
      codigo: new FormControl('', [Validators.required]),
      observaciones: new FormControl('', []),
    });
  }

  public cancelarButton() {
    this.dlgref.close();
  }

  public validaCodigo() {
    console.log('Codigo:', this.formGroup.controls.codigo.value);
    if (this.formGroup.controls.codigo.value === '123456') {
      this.correlacionado = true;
    } else {
      this.correlacionado = false;
    }
  }

  public acteptarButton() {
    this.dlgref.close();
  }

}
