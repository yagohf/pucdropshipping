import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ProdutoCatalogo } from '../_models/produtocatalogo';
import { Listagem } from '../_models/infraestrutura/listagem';

@Injectable({
  providedIn: 'root'
})
export class ProdutosService {
  constructor(private http: HttpClient) { }

  listarMaisVendidos(): Observable<ProdutoCatalogo[]> {
    const url = `${environment.enderecoApi}/produtos/maisvendidos?quantidadeRegistrosExibir=${environment.qtdProdutosDestaqueExibir}`;
    return this.http.get<ProdutoCatalogo[]>(url)
      .pipe(
        tap(_ => console.log(_))
      );
  }

  listarPorCategoria(categoria: number, pagina: number): Observable<Listagem<ProdutoCatalogo>> {
    const url = `${environment.enderecoApi}/produtos/categoria/${categoria}?pagina=${pagina}`;
    return this.http.get<Listagem<ProdutoCatalogo>>(url)
      .pipe(
        tap(_ => console.log(_))
      );
  };

  listarPorPromocao(promocao: number, pagina: number): Observable<Listagem<ProdutoCatalogo>> {
    const url = `${environment.enderecoApi}/produtos/promocao/${promocao}?pagina=${pagina}`;
    return this.http.get<Listagem<ProdutoCatalogo>>(url)
      .pipe(
        tap(_ => console.log(_))
      );
  }

  listarPorNome(nome: string, pagina: number): any {
    const url = `${environment.enderecoApi}/produtos/?nome=${nome}&pagina=${pagina}`;
    return this.http.get<Listagem<ProdutoCatalogo>>(url)
      .pipe(
        tap(_ => console.log(_))
      );
  }
}
