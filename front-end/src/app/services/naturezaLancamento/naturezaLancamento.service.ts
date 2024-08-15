import { TituloAPagar } from './../../models/titulo-pagar.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class NaturezaLancamentoService {
  private url = environment.api;

  constructor(private httpClient: HttpClient) {}

  obterTodos() {
    return this.httpClient.get<TituloAPagar>(`${this.url}/titulos-a-pagar`);
  }

  obterPorId(id: string) {
    return this.httpClient.get<TituloAPagar>(
      `${this.url}/titulos-a-pagar/${id}`,
    );
  }

  cadastrar(tituloPagar: TituloAPagar) {
    return this.httpClient.post(`${this.url}/titulos-a-pagar`, tituloPagar);
  }

  editar(tituloAPagar: TituloAPagar) {
    return this.httpClient.put(
      `${this.url}/titulos-a-pagar/${tituloAPagar.id}`,
      tituloAPagar,
    );
  }

  deletar(id: string) {
    return this.httpClient.delete(`${this.url}/titulos-a-pagar/${id}`);
  }
}
