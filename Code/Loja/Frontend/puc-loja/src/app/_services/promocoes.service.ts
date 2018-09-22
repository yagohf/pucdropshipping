import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Promocao } from '../_models/promocao';

@Injectable({
  providedIn: 'root'
})
export class PromocoesService {

  constructor(private http: HttpClient) { }

  listar(): Observable<Promocao[]> {
    const url = `${environment.enderecoApi}/promocoes`;
    return this.http.get<Promocao[]>(url);
  }
}
