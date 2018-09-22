import { Component, OnInit } from '@angular/core';
import { Produto } from '../shared/models/produto';

@Component({
  selector: 'app-catalogo',
  templateUrl: './catalogo.component.html',
  styleUrls: ['./catalogo.component.css']
})
export class CatalogoComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  termoPesquisa: string = "Tênis";
  produtos: Produto[] = [
    { Id: 1, Nome: `Produto 1`, Descricao: `Descrição do produto 1 teste pra quebrar linha pra ver até onde o layout se comporta corretamente vamos aí cara, que coisa complicada. Angular é foda`, UrlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}`, Disponivel: true, Preco: 200.00 },
    { Id: 1, Nome: `Produto 1`, Descricao: `Descrição do produto 1`, UrlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}`, Disponivel: true, Preco: 250.00 },
    { Id: 1, Nome: `Produto 1`, Descricao: `Descrição do produto 1`, UrlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}`, Disponivel: true, Preco: 100.00 },
    { Id: 1, Nome: `Produto 1`, Descricao: `Descrição do produto 1`, UrlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}`, Disponivel: true, Preco: 100.00 }
  ];
}
