import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (localStorage.getItem('usuarioLogado')) {
            //Usuário autenticado, então permitir.
            return true;
        }

        //Usuário não autenticado, redirecionar para tela de login.
        this.router.navigate(['/acesse'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}