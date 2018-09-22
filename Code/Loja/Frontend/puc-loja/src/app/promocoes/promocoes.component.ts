import { Component, OnInit } from '@angular/core';
import { Promocao } from '../_models/promocao';

@Component({
  selector: 'app-promocoes',
  templateUrl: './promocoes.component.html',
  styleUrls: ['./promocoes.component.css']
})
export class PromocoesComponent implements OnInit {

  constructor() { }

  ngOnInit() {

  }

  promocoes: Promocao[] = [
    { id: 1, nome: `Promoção 1`, descricao: `Descrição da promoção 1`, urlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}` },
    { id: 1, nome: `Promoção 1`, descricao: `Descrição da promoção 1`, urlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}` },
    { id: 1, nome: `Promoção 1`, descricao: `Descrição da promoção 1`, urlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}` },
    { id: 1, nome: `Promoção 1`, descricao: `Descrição da promoção 1`, urlImagem: `https://picsum.photos/900/500?random&t=${Math.random()}` }
  ];
}
