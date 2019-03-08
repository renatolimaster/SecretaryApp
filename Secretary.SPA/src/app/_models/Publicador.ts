import { Dianteira } from './Dianteira';
import { Grupo } from './Grupo';
import { Estado } from './Estado';
import { Country } from './Country';
import { TipoLogradouro } from './TipoLogradouro';
import { Pioneiro } from './Pioneiro';
import { Situacao } from './Situacao';
import { Congregacao } from './Congregacao';

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
  pioneiro: Pioneiro;
  sexo: boolean;
  situacaoServicoCampo: string;
  telCelular: string;
  congregacaoId: number;
  congregacao: Congregacao;
  estado: Estado;
  cep: string;
  country: Country;
  tipoLogradouro: TipoLogradouro;
  complemento: string;
  nomeLogradouro: string;
  bairro: string;
  cidade: string;
  situacao: Situacao;
  //
  irmaoBatizado: boolean;
  chefeFamilia: boolean;
  dataAnciao: Date;
  dataInativo: Date;
  dataInicioServico: Date;
  dataReativado: Date;
  dataServoMinisterial: Date;
  batismo: Date;
  telResidencial: string;
  telTrabalho: string;
  email: string;
}
