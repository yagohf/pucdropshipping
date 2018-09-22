import { Component, OnInit } from '@angular/core';
import { Categoria } from '../_models/categoria';

@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  categorias: Categoria[] = [
    { Id: 1, Nome: 'Tênis', QtdItens: 10 },
    { Id: 2, Nome: 'Chinelos', QtdItens: 153 },
    { Id: 3, Nome: 'Sapatilhas', QtdItens: 205 },
    { Id: 4, Nome: 'Sandálias', QtdItens: 150 }
  ];
}
