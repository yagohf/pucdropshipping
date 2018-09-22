import { Component, OnInit } from '@angular/core';
import { Produto } from '../_models/produto';

@Component({
  selector: 'app-maisvendidos',
  templateUrl: './maisvendidos.component.html',
  styleUrls: ['./maisvendidos.component.css']
})
export class MaisvendidosComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  produtos: Produto[] = [
    { Id: 1, Nome: `Produto 1`, Descricao: `Descrição do produto 1 teste pra quebrar linha pra ver até onde o layout se comporta corretamente vamos aí cara, que coisa complicada. Angular é foda`, UrlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}`, Disponivel: true, Preco: 200.00 },
    { Id: 1, Nome: `Produto 1`, Descricao: `Descrição do produto 1`, UrlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}`, Disponivel: true, Preco: 250.00 },
    { Id: 1, Nome: `Produto 1`, Descricao: `Descrição do produto 1`, UrlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}`, Disponivel: true, Preco: 550.00 },
    { Id: 1, Nome: `Produto 1`, Descricao: `Descrição do produto 1`, UrlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}`, Disponivel: true, Preco: 100.00 }
  ];
}
