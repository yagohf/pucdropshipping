import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  isCollapsed = true;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  pesquisarCatalogo(texto: string) {
    if (!texto) {
      return;
    }
    else {
      this.router.navigate(['/catalogo'], { queryParams: { q: texto } });
    }
  }
}
