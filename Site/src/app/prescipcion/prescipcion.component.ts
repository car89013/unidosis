import { Component, OnInit } from '@angular/core';
import {GridOptions} from 'ag-grid';

@Component({
  selector: 'app-prescipcion',
  templateUrl: './prescipcion.component.html',
  styleUrls: ['./prescipcion.component.scss']
})
export class PrescipcionComponent implements OnInit {

  bitacroraGrid: GridOptions;
  editando: true;
  brazalete: string;

  constructor() { }

  ngOnInit() {
  }

}
