import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  isCollapsed = true;

  constructor(private router: Router, private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.isUsuarioLogado$ = this.authenticationService.isUsuarioLogado;
  }

  pesquisarCatalogo(texto: string) {
    if (!texto) {
      return;
    }
    else {
      this.router.navigate(['/catalogo'], { queryParams: { q: texto } });
    }
  }

  logoff() {
    this.authenticationService.logout();
    this.router.navigate(['/home']);
  }

  isUsuarioLogado$: Observable<boolean>;
}
