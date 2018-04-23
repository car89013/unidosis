import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Medicos} from '../models/medicos';

@Injectable()
export class MedicosService {

  headers = new HttpHeaders({'Content-Type' : 'application/json'});

  constructor(private http: HttpClient) { }


  public getAllMedicos() {
    return this.http.get('http://172.16.1.71/Unidosis/api/Medicos').toPromise();
  }

  public setMedico(medico: Medicos) {
    console.log('Mandando medico -> ', medico);
    return this.http.post('http://172.16.1.71/Unidosis/api/Medicos', JSON.stringify(medico), { headers: this.headers }).toPromise();
  }

  public putMedico(medico: Medicos) {
    return this.http.put('http://172.16.1.71/Unidosis/api/Medicos', JSON.stringify(medico), { headers: this.headers}).toPromise();
  }
}
