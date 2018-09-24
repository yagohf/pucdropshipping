import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Compra } from '../_models/compra';
import { Venda } from '../_models/venda';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Listagem } from '../_models/infraestrutura/listagem';

@Injectable({
  providedIn: 'root'
})
export class PedidosService {

  constructor(private http: HttpClient) { }

  listarCompras(usuario: number, pagina: number) : Observable<Listagem<Compra>> {
    const url = `${environment.enderecoApi}/pedidos/cliente/${ usuario }?pagina=${pagina}`;
    return this.http.get<Listagem<Compra>>(url)
    .pipe(
      tap(_ => console.log(_))
    );;
  }

  listarVendas(usuario: number, pagina: number) : Observable<Listagem<Venda>> {
    const url = `${environment.enderecoApi}/pedidos/vendedor/${ usuario }?pagina=${pagina}`;
    return this.http.get<Listagem<Venda>>(url)
    .pipe(
      tap(_ => console.log(_))
    );;
  }
}
