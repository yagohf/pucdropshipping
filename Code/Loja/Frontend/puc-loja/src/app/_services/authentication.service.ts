import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Login } from '../_models/login';
import { map } from 'rxjs/operators';
import { EnumPerfil } from '../_models/enums/enum.perfil';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class AuthenticationService {
  constructor(private http: HttpClient) { }

  //Observable para expor o status do usuário como logado ou não.
  private usuarioLogado = new BehaviorSubject<boolean>(this.verificarTokenExistente());
  get isUsuarioLogado() {
    return this.usuarioLogado.asObservable();
  }

  login(usuario: Login) {
    return this.http.post<any>(`${environment.enderecoApi}/usuarios/autenticar`, { login: usuario.usuario, senha: usuario.senha })
      .pipe(map(user => {
        //Login com sucesso se o retorno contiver um token.
        if (user && user.token) {
          //Guardar o token em localstorage para poder manter o usuário logado entre refreshs.
          localStorage.setItem('usuarioLogado', JSON.stringify(user));
        }

        //Enviar mensagem de usuário logado para quem quer que esteja observando.
        this.usuarioLogado.next(true);
        return user;
      }));
  }

  logout() {
    //Remover o usuário da localstorage.
    localStorage.removeItem('usuarioLogado');

    //Enviar mensagem de usuário deslogado para quem quer que esteja observando.
    this.usuarioLogado.next(false);
  }

  verificarTokenExistente(): boolean {
    if (localStorage.getItem('usuarioLogado')) {
      return true;
    }
    else {
      return false;
    }
  }

  verificarPermissao(perfil: EnumPerfil): boolean {
    var token = localStorage.getItem('usuarioLogado');
    if (!token) {
      return false;
    }
    else {
      var objetoCorpoJWT = this.obterTokenDecodificado(token);
      switch (perfil) {
        case EnumPerfil.CLIENTE:
          return objetoCorpoJWT['CLIENTE'] && objetoCorpoJWT['CLIENTE'] == 1;
        case EnumPerfil.VENDEDOR:
          return objetoCorpoJWT['VENDEDOR'] && objetoCorpoJWT['VENDEDOR'] == 1;
        default:
          console.log('Impossível verificar se o usuário possui o perfil informado');
          break;
      }
    }
  }

  obterUsuarioLogado(): number {
    var token = localStorage.getItem('usuarioLogado');
    if (!token) {
      return null;
    }
    else {
      var objetoCorpoJWT = this.obterTokenDecodificado(token);
      return parseInt(objetoCorpoJWT['unique_name']);
    }
  }

  private obterTokenDecodificado(token: string): any {
    var corpoJWT = token.split('.')[1];
    var objetoCorpoJWT = JSON.parse(window.atob(corpoJWT));
    return objetoCorpoJWT;
  }
}