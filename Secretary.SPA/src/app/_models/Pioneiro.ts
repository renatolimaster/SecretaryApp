import { Congregacao } from './Congregacao';
import { Publicador } from './Publicador';
import { ServicoCampo } from './ServicoCampo';

export interface Pioneiro {
    id: number;
    auditoriaUsuario: number;
    descricao: string;
    observacao: string;
    // ForeignKey
    congregacaoId: number;
    congregacao: Congregacao;
    // Collections
    publicador: Publicador[];
    servicoCampo: ServicoCampo[];
}
