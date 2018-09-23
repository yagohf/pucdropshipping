import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Propaganda } from '../_models/propaganda';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PropagandasService {

  constructor(private http: HttpClient) { }

  listar(): Observable<Propaganda[]> {
    const url = `${environment.enderecoApi}/propagandas`;
    return this.http.get<Propaganda[]>(url);
  }
}
