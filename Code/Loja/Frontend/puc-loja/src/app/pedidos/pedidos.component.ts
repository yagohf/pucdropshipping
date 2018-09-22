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
    { id: 1, data: new Date(), valor: 350.00, descricaoProdutos: ["Tênis Nike Xyz C3PO", "Pão com ovo"] },
    { id: 2, data: new Date(), valor: 450.00, descricaoProdutos: ["Tênis Nike Xyz C3PO", "Pão com ovo"] }
  ];

  vendas: Venda[] = [
    { id: 1, data: new Date(), valor: 350.00, nomeCliente: 'Yago', descricaoProdutos: ["Tênis Nike Xyz C3PO", "Pão com ovo"] },
    { id: 2, data: new Date(), valor: 450.00, nomeCliente: 'Yago', descricaoProdutos: ["Tênis Nike Xyz C3PO", "Pão com ovo"] }
  ];
}
