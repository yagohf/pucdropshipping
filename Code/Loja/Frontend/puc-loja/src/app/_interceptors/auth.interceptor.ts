import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        //Adicionar o token de autenticação a cada request.
        let usuarioLogado = JSON.parse(localStorage.getItem('usuarioLogado'));
        if (usuarioLogado) {
            request = request.clone({
                setHeaders: { 
                    Authorization: `Bearer ${usuarioLogado}`
                }
            });
        }

        return next.handle(request);
    }
}