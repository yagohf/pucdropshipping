import { Injectable } from '@angular/core';
import { Observable,Subject} from 'rxjs';
import { EnumMensagem } from '../_models/enums/enum.mensagem';

@Injectable({
  providedIn: 'root'
})
export class MensagensService {
  private subject = new Subject<any>();

  constructor() { }

  enviarMensagem(mensagem: string, tipo: EnumMensagem) {
      this.subject.next({ texto: mensagem, tipo: tipo});
  }

  getMensagens(): Observable<any> {
      return this.subject.asObservable();
  }
}
