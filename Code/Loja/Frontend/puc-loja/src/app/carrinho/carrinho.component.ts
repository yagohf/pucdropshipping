import { Component, OnInit } from '@angular/core';
import { CarrinhoService } from '../_services/carrinho.service';
import { ProdutoCarrinho } from '../_models/produtocarrinho';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})
export class CarrinhoComponent implements OnInit {

  constructor(private carrinhoService: CarrinhoService) { }

  ngOnInit() {
    this.infosCarrinho$ = this.carrinhoService.infosCarrinho;
  }

  mudarQuantidade(prod: ProdutoCarrinho, operacao: string) {
    let qtd = prod.quantidade;
    if (operacao === '+') {
      qtd += 1;
    }
    else {
      qtd -= 1;
    }

    this.carrinhoService.atualizarQuantidade(prod.id, qtd);
  }

  removerProduto(id: number) {
    this.carrinhoService.removerProduto(id);
  }

  infosCarrinho$: Observable<ProdutoCarrinho[]>;
}
