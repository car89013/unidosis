import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {ConfigService} from './config.service';

@Injectable()
export class IngresosService {

  public numBrazalete: string;

  headers = new HttpHeaders({'Content-Type' : 'application/json'});

  constructor( private http: HttpClient, private config: ConfigService) {
    const cfg = this.config.getConfigs();
    console.log('Info Config ', cfg);
  }

  public getInfoPacieteByBrazaleteId( numbrazalete: string) {
    return this.http.get('http://172.16.1.71/Unidosis/api/Ingresos?numbrazalete=' + numbrazalete).toPromise();
  }

  public getIngresosBySalaId(idSala: number, activos: boolean) {
    return this.http.get('http://172.16.1.71/Unidosis/api/Ingresos?idSala=' + idSala + '&activos=' + activos ).toPromise();
  }

}
