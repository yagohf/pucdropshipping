import { Component, OnInit, Input } from '@angular/core';
import { ProdutoCatalogo } from '../_models/produtocatalogo';
import { CarrinhoService } from '../_services/carrinho.service';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  @Input() produto: ProdutoCatalogo;
  
  constructor(private carrinhoService: CarrinhoService) { }

  ngOnInit() {
  }

  adicionarCarrinho(produto: ProdutoCatalogo){
    this.carrinhoService.adicionarProduto(produto);
  }
}
