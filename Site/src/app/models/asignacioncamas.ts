import {Salas} from './salas';
import {Camas} from './camas';
import {Ingresos} from './ingresos';

export class Asignacioncamas {
  id: number;
  sala: Salas;
  fk_sala: number;
  cama: Camas;
  fk_cama: number;
  ingresos: Ingresos[];
}
