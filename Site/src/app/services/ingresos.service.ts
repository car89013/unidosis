import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable()
export class IngresosService {

  headers = new HttpHeaders({'Content-Type' : 'application/json'});

  constructor( private http: HttpClient) { }

  public getInfoPacieteByBrazaleteId( numbrazalete: string) {
    return this.http.get('http://172.16.1.71/Unidosis/api/Ingresos?numbrazalete=' + numbrazalete).toPromise();
  }

}
