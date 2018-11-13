import { Dianteira } from './Dianteira';
import { Grupo } from './Grupo';

export interface Publicador {
  id: number;
  nome: string;
  primeiroNome: string;
  nomeSobrenome: string;
  dataNascimento: Date;
  age: number;
  dianteiraId: number;
  dianteira?: Dianteira;
  grupoId: number;
  grupo: Grupo;
  pioneiroId: number;
  pioneiro: string;
  sexo: boolean;
  situacaoServicoCampo: string;
  telCelular: string;
  situacao: string;
  congregacaoId: number;
}
