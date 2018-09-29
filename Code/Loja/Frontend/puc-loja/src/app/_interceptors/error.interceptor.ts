import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { AuthenticationService } from '../_services/authentication.service';
import { MensagensService } from '../_services/mensagens.service';
import { EnumMensagem } from '../_models/enums/enum.mensagem';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService, private mensagemService: MensagensService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            if (err.status === 401) {
                //Se o servidor retornar 401, automaticamente forçar o logout e recarregar a URL.
                this.authenticationService.logout();
                location.reload(true);
            } 
            else if(err.status === 0) {
                this.mensagemService.enviarMensagem('Ops... Estamos com uma indisponibilidade em nossos serviços. Por favor, tente novamente dentro de alguns instantes.', EnumMensagem.ERRO);
            }
            else if (err.status === 500) {
                this.mensagemService.enviarMensagem('Ops... Parece que ocorreu um problema ao processar sua solicitação. Por favor, tente novamente.', EnumMensagem.ERRO);
            }

            const error = err.error.message || err.statusText;
            return throwError(error);
        }))
    }
}