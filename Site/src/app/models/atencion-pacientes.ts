import {Pacientes} from './pacientes';
import {BitacoraPacientes} from './bitacora-pacientes';
import {Asignacioncamas} from './asignacioncamas';

export class AtencionPacientes {
  id: number;
  paciente: Pacientes;
  fk_paciente: string;
  num_brazalete: string;
  fecha_ingreso: string;
  fecha_egreso: string;
  bitacora: BitacoraPacientes[];
  asignacion: Asignacioncamas;
}
