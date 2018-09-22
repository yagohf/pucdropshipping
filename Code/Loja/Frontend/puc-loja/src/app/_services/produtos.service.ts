import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Produto } from '../_models/produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutosService {

  constructor(private http: HttpClient) { }

  listarMaisVendidos(): Observable<Produto[]> {
    const url = `${environment.enderecoApi}/produtos/maisvendidos?quantidadeRegistrosExibir=${environment.qtdProdutosDestaqueExibir}`;
    return this.http.get<Produto[]>(url)
      .pipe(
        tap(_ => console.log(_))
      );
  }

  listarPorCategoria(categoria: number): Observable<Produto[]> {
    const url = `${environment.enderecoApi}/produtos/categoria/${categoria}`;
    return this.http.get<Produto[]>(url)
      .pipe(
        tap(_ => console.log(_))
      );
  };
}
