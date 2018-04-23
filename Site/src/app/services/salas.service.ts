import { Injectable } from '@angular/core';
import {Salas} from '../models/salas';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable()
export class SalasService {

  headers = new HttpHeaders({'Content-Type' : 'application/json'});

  constructor(private http: HttpClient) { }


  public getAllSalas() {
    return this.http.get('http://172.16.1.71/Unidosis/api/Salas').toPromise();
  }

  public setSala(sala: Salas) {
    console.log('Mandando sala -> ', sala);
    return this.http.post('http://172.16.1.71/Unidosis/api/Salas', JSON.stringify(sala), { headers: this.headers }).toPromise();
  }

  public putSala(sala: Salas) {
    return this.http.put('http://172.16.1.71/Unidosis/api/Salas', JSON.stringify(sala), { headers: this.headers}).toPromise();
  }
  public getCamasDisponibles(id: number, disponibles: boolean) {
    return this.http.get('http://172.16.1.71/Unidosis/api/Salas/' + id + '?disponibles=' + disponibles).toPromise();
  }

}
