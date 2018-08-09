export interface Congregacao {
  id: number;
  nome: string;
  coordenador: string;
  padrao: boolean;
  tipoLogradouroId: number;
  tipoLogradouro: string;
  nomeLogradouro: string;
  numero: string;
  complemento: string;
  bairro: string;
  cidade: string;
  estadoId: number;
  estado: string;
  countryId: number;
  cep: string;
  email: string;
  telCelular: string;
  telResidencial: string;
  telTrabalho: string;
  telefone: string;
}
