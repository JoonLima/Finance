export interface TituloAReceber {
  id?: string;
  idUsuario: string;
  idNaturezaLancamento?: string;
  descricao: string;
  valorOriginal: number;
  valorRecebido: number;
  observacao?: string;
  dataCadastro: Date;
  dataVencimento?: Date;
  dataRecebimento?: Date;
}
