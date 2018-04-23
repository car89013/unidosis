import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Enfermeras} from '../models/enfermeras';

@Injectable()
export class EnfermerasService {

  headers = new HttpHeaders({'Content-Type' : 'application/json'});

  constructor(private http: HttpClient) { }


  public getAllEnfermeras() {
    return this.http.get('http://172.16.1.71/Unidosis/api/Enfermeras').toPromise();
  }

  public setEnfermera(enfermera: Enfermeras) {
    console.log('Mandando enfermera -> ', enfermera);
    return this.http.post('http://172.16.1.71/Unidosis/api/Enfermeras', JSON.stringify(enfermera), { headers: this.headers }).toPromise();
  }

  public putEnfermera(enfermera: Enfermeras) {
    return this.http.put('http://172.16.1.71/Unidosis/api/Enfermeras', JSON.stringify(enfermera), { headers: this.headers}).toPromise();
  }

}
