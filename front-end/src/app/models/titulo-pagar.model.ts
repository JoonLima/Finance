export interface TituloAPagar {
  id?: string;
  idUsuario: string;
  idNaturezaLancamento?: string;
  descricao: string;
  valorOriginal: number;
  valorPago: number;
  observacao?: string;
  dataCadastro: Date;
  dataVencimento?: Date;
  dataPagamento?: Date;
}
