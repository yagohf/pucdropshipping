import { Component, OnInit } from '@angular/core';
import { Compra } from '../_models/compra';
import { Venda } from '../_models/venda';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  exibirCompras: boolean = true;
  exibirVendas: boolean = true;

  compras: Compra[] = [
    { Id: 1, Data: new Date(), Valor: 350.00, DescricaoProdutos: ["Tênis Nike Xyz C3PO", "Pão com ovo"] },
    { Id: 2, Data: new Date(), Valor: 450.00, DescricaoProdutos: ["Tênis Nike Xyz C3PO", "Pão com ovo"] }
  ];

  vendas: Venda[] = [
    { Id: 1, Data: new Date(), Valor: 350.00, NomeCliente: 'Yago', DescricaoProdutos: ["Tênis Nike Xyz C3PO", "Pão com ovo"] },
    { Id: 2, Data: new Date(), Valor: 450.00, NomeCliente: 'Yago', DescricaoProdutos: ["Tênis Nike Xyz C3PO", "Pão com ovo"] }
  ];
}
