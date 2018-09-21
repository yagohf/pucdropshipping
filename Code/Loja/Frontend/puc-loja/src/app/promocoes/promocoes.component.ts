import { Component, OnInit } from '@angular/core';
import { Promocao } from '../shared/models/Promocao';

@Component({
  selector: 'app-promocoes',
  templateUrl: './promocoes.component.html',
  styleUrls: ['./promocoes.component.css']
})
export class PromocoesComponent implements OnInit {

  constructor() { }

  ngOnInit() {
   
  }

  promocoes: Array<Promocao[]> = [
    [
      { Id: 1, Nome: `Promoção 1`, Descricao: `Descrição da promoção 1`, UrlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}` },
      { Id: 1, Nome: `Promoção 1`, Descricao: `Descrição da promoção 1`, UrlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}` },
      { Id: 1, Nome: `Promoção 1`, Descricao: `Descrição da promoção 1`, UrlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}` }
    ],
    [
      { Id: 1, Nome: `Promoção 1`, Descricao: `Descrição da promoção 1`, UrlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}` }
    ]
  ];
}
