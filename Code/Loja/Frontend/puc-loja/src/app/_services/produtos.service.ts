import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Produto } from '../_models/produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutosService {

  constructor(private http: HttpClient) { }

  listarMaisVendidos() : Observable<Produto[]> {
    const url = `${environment.enderecoApi}/produtos/maisvendidos?quantidadeRegistrosExibir=${environment.qtdProdutosDestaqueExibir}`;
    return this.http.get<Produto[]>(url);
  }
}
