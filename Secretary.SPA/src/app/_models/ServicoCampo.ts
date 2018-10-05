import { Publicador } from './Publicador';
import { Congregacao } from './Congregacao';
import { Pioneiro } from './Pioneiro';

export interface ServicoCampo {
  id: number;
  anoReferencia: number;
  dataEntrega: Date;
  dataReferencia: Date;
  estudos: number;
  folhetosBrochuras: number;
  horas: number;
  livros: number;
  mesReferencia: number;
  minutos: number;
  observacao: string;
  revisitas: number;
  revistas: number;
  publicacoes: number;
  videosMostrados: number;
  horasBetel: number;
  creditoHoras: number;
  // ForeignKey
  pioneiroId: number;
  pioneiro: Pioneiro;
  congregacaoId: number;
  congregacao?: Congregacao;
  publicadorId: number;
  publicador?: Publicador;
}
