import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Medicos} from '../models/medicos';
import {Pacientes} from '../models/pacientes';

@Injectable()
export class PacientesService {

  headers = new HttpHeaders({'Content-Type' : 'application/json'});

  constructor(private http: HttpClient) { }


  public getAllPacientes() {
    return this.http.get('http://172.16.1.71/Unidosis/api/Pacientes').toPromise();
  }

  public setPaciente(paciente: Pacientes) {
    console.log('Mandando paciente -> ', paciente);
    return this.http.post('http://172.16.1.71/Unidosis/api/Pacientes', JSON.stringify(paciente), { headers: this.headers }).toPromise();
  }

  public putPaciente(paciente: Pacientes) {
    return this.http.put('http://172.16.1.71/Unidosis/api/Pacientes', JSON.stringify(paciente), { headers: this.headers}).toPromise();
  }

}
