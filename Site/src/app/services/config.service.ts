import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class ConfigService {

  constructor(private http: HttpClient) {}

  public getConfigs(): Promise <any> {
    return new Promise<any>((resolve, reject) => {
      this.http.get('./../../assets/config.json')
        .subscribe(
          (res: any) => {
            console.log(res);
            if (!res.ok) {
              reject('Falla con status: ' + res.status + '\nTratando de localizar el archivo en el path ./assets/config.json');
            }
             const jsonRes = res.json();
            resolve(jsonRes);
          }
        );
    }).catch((reason) => this.handleError(reason));
  }

  private handleError(error: Response | any) {
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    }
    console.error(errMsg);
    return Observable.throw(errMsg);
  }

}
