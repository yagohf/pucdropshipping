import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Categoria } from '../_models/categoria';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  constructor(private http: HttpClient) { }

  listar() : Observable<Categoria[]> {
    const url = `${environment.enderecoApi}/categorias`;
    return this.http.get<Categoria[]>(url);
  }
}
