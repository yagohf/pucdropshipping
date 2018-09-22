import { Component, OnInit } from '@angular/core';
import { Produto } from '../_models/produto';

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
    { id: 1, nome: `Produto 1`, descricao: `Descrição do produto 1 teste pra quebrar linha pra ver até onde o layout se comporta corretamente vamos aí cara, que coisa complicada. Angular é foda`, urlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}`, disponivel: true, preco: 200.00 },
    { id: 1, nome: `Produto 1`, descricao: `Descrição do produto 1`, urlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}`, disponivel: true, preco: 250.00 },
    { id: 1, nome: `Produto 1`, descricao: `Descrição do produto 1`, urlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}`, disponivel: true, preco: 100.00 },
    { id: 1, nome: `Produto 1`, descricao: `Descrição do produto 1`, urlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}`, disponivel: true, preco: 100.00 }
  ];
}
