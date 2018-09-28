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
    return this.http.post<any>(`${environment.enderecoApiAutenticacao}/usuarios/autenticar`, { usuario: usuario.usuario, senha: usuario.senha })
      .pipe(map(resultado => {
        console.log(resultado);

        //Login com sucesso se o retorno contiver um token.
        if (resultado && resultado.status == 1 && resultado.token) {
          console.log('valido');
          //Guardar o token em localstorage para poder manter o usuário logado entre refreshs.
          localStorage.setItem('usuarioLogado', JSON.stringify(resultado));
        }

        //Enviar mensagem de usuário logado para quem quer que esteja observando.
        this.usuarioLogado.next(true);
        return resultado;
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
    //TODO - tratar token do cognito.
    return true;
    // var token = localStorage.getItem('usuarioLogado');
    // if (!token) {
    //   return false;
    // }
    // else {
    //   var objetoCorpoJWT = this.obterTokenDecodificado(token);
    //   switch (perfil) {
    //     case EnumPerfil.CLIENTE:
    //       return objetoCorpoJWT['CLIENTE'] && objetoCorpoJWT['CLIENTE'] == 1;
    //     case EnumPerfil.VENDEDOR:
    //       return objetoCorpoJWT['VENDEDOR'] && objetoCorpoJWT['VENDEDOR'] == 1;
    //     default:
    //       console.log('Impossível verificar se o usuário possui o perfil informado');
    //       break;
    //   }
    // }
  }

  obterUsuarioLogado(): number {
    //TODO - tratar token do cognito.
    return 1;
    // var token = localStorage.getItem('usuarioLogado');
    // if (!token) {
    //   return null;
    // }
    // else {
    //   var objetoCorpoJWT = this.obterTokenDecodificado(token);
    //   return parseInt(objetoCorpoJWT['unique_name']);
    // }
  }

  private obterTokenDecodificado(token: string): any {
    //TODO - tratar token do cognito.
    // var corpoJWT = token.split('.')[1];
    // var objetoCorpoJWT = JSON.parse(window.atob(corpoJWT));
    // return objetoCorpoJWT;
  }
}