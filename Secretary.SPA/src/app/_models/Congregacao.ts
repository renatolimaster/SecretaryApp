import { Estado } from './Estado';
import { TipoLogradouro } from './TipoLogradouro';

export interface Congregacao {
  id: number;
  nome: string;
  coordenador: string;
  padrao: boolean;
  tipoLogradouroId: number;
  tipoLogradouro: TipoLogradouro;
  nomeLogradouro: string;
  numero: string;
  complemento: string;
  bairro: string;
  cidade: string;
  estadoId: number;
  estado: Estado;
  countryId: number;
  cep: string;
  email: string;
  telCelular: string;
  telResidencial: string;
  telTrabalho: string;
  telefone: string;
  auditoriaUsuario: number;
}
