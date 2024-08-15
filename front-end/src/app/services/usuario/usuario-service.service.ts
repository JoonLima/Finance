import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Usuario } from '../../models/usuario.model';

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  private url = environment.api;

  constructor(private httpClient: HttpClient) {}

  login(email: string, senha: string) {
    return this.httpClient.post<Usuario>(`${this.url}/usuario/login`, {
      email,
      senha,
    });
  }
}
