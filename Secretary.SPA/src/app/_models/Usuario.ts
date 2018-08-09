import { Publicador } from './Publicador';
import { Congregacao } from './Congregacao';

export interface Usuario {
  id: number;
  username: string;
  email: string;
  congregacaoId: number;
  congregacao: Congregacao[];
  publicadorId: number;
  publicador: Publicador[];
}
