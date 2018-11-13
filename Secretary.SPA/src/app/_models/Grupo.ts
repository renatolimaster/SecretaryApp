import { Publicador } from './Publicador';
import { Congregacao } from './Congregacao';

export interface Grupo {
  id: number;
  local: string;
  ajudanteId: number;
  ajudante: Publicador;
  congregacaoId: number;
  congregacao: Congregacao;
  superintendenteId: number;
  superintendente: Publicador;
}
