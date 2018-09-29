import { Injectable } from '@angular/core';
import { ProdutoCarrinho } from '../_models/produtocarrinho';
import { BehaviorSubject } from 'rxjs';
import { ProdutoBase } from '../_models/produtobase';
import { MensagensService } from './mensagens.service';
import { EnumMensagem } from '../_models/enums/enum.mensagem';

@Injectable({
  providedIn: 'root'
})
export class CarrinhoService {
  //Observable para expor o status do carrinho.
  private produtosSub = new BehaviorSubject<ProdutoCarrinho[]>(this.obterCarrinho());
  get infosCarrinho() {
    return this.produtosSub.asObservable();
  }

  constructor(private mensagemService: MensagensService) { }

  persistirCarrinho(carrinho: ProdutoCarrinho[]) {
    localStorage.setItem('carrinho', JSON.stringify(carrinho));
  }

  obterCarrinho(): ProdutoCarrinho[] {
    if (localStorage.getItem('carrinho')) {
      return JSON.parse(localStorage.getItem('carrinho'));
    }
    else {
      return [];
    }
  }

  adicionarProduto(prod: ProdutoBase) {
    var carrinho = this.obterCarrinho();
    var produtoExistente = carrinho.find(x => x.id === prod.id);
    if (produtoExistente) {
      produtoExistente.quantidade += 1;
    }
    else {
      let prodAdicionar = new ProdutoCarrinho();
      prodAdicionar.id = prod.id;
      prodAdicionar.nome = prod.nome;
      prodAdicionar.preco = prod.preco;
      prodAdicionar.quantidade = 1;
      prodAdicionar.descricao = prod.descricao;
      carrinho.push(prodAdicionar);
    }
    
    this.persistirCarrinho(carrinho);
    this.produtosSub.next(carrinho);
    this.mensagemService.enviarMensagem('Produto adicionado ao carrinho.', EnumMensagem.SUCESSO);
  }

  atualizarQuantidade(id: number, quantidade: number) {
    var carrinho = this.obterCarrinho();
    var prodAtualizar = carrinho.find(x => x.id === id);
    prodAtualizar.quantidade = quantidade;
    
    this.persistirCarrinho(carrinho);
    this.produtosSub.next(carrinho);
  }

  removerProduto(id: number) {
    var carrinho = this.obterCarrinho();
    var prodRemover = carrinho.find(x => x.id === id);
    carrinho.splice(carrinho.indexOf(prodRemover), 1);

    this.persistirCarrinho(carrinho);
    this.produtosSub.next(carrinho);
    this.mensagemService.enviarMensagem('Produto removido do carrinho.', EnumMensagem.SUCESSO);
  }
}
