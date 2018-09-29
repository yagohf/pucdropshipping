import { Component, OnInit } from '@angular/core';
import { ProdutoCatalogo } from '../_models/produtocatalogo';
import { ProdutosService } from '../_services/produtos.service';
import { ActivatedRoute } from '@angular/router';
import { Listagem } from '../_models/infraestrutura/listagem';
import { PagerService } from '../_services/pager.service';
import { Paginacao } from '../_models/infraestrutura/paginacao';
import { EnumCatalogo } from '../_models/enums/enum.catalogo';

@Component({
  selector: 'app-catalogo',
  templateUrl: './catalogo.component.html',
  styleUrls: ['./catalogo.component.css']
})
export class CatalogoComponent implements OnInit {

  constructor(private route: ActivatedRoute, private produtosService: ProdutosService, private pagerService: PagerService) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (params['categoria']) {
        this.tipoCatalogo = EnumCatalogo.CATEGORIA;
        this.categoria = parseInt(params['categoria']);
        this.termoPesquisa = params['nomecategoria'];
        this.listarPorCategoria(1);
      }
      else if (params['promocao']) {
        this.tipoCatalogo = EnumCatalogo.PROMOCAO;
        this.promocao = parseInt(params['promocao']);
        this.termoPesquisa = params['nomepromocao'];
        this.listarPorPromocao(1);
      }
      else if (params['q']) {
        this.tipoCatalogo = EnumCatalogo.TEXTO;
        this.termoPesquisa = params['q'];
        this.listarPorNome(1);
      }
    });
  }

  listarPorCategoria(pagina: number) {
    this.produtosService.listarPorCategoria(this.categoria, pagina).subscribe(retorno => {
      this.produtos = retorno;
      this.atualizarPager(retorno.paginacao);
    });
  }

  listarPorPromocao(pagina: number) {
    this.produtosService.listarPorPromocao(this.promocao, pagina).subscribe(retorno => {
      this.produtos = retorno;
      this.atualizarPager(retorno.paginacao);
    });
  }

  listarPorNome(pagina: number): any {
    this.produtosService.listarPorNome(this.termoPesquisa, pagina).subscribe(retorno => {
      this.produtos = retorno;
      this.atualizarPager(retorno.paginacao);
    });
  }

  atualizarPager(paginacao: Paginacao) {
    this.pager = this.pagerService.getPager(paginacao.totalRegistros, paginacao.paginaAtual);
  }

  setPage(p: number, desabilitado: boolean) {
    if (desabilitado) {
      return;
    }

    switch (this.tipoCatalogo) {
      case EnumCatalogo.CATEGORIA:
        this.listarPorCategoria(p);
        break;
      case EnumCatalogo.PROMOCAO:
        this.listarPorPromocao(p);
        break;
      case EnumCatalogo.TEXTO:
        this.listarPorNome(p);
        break;
      default:
        console.log('Impossível paginar com os critérios informados.');
        break;
    }
  }

  forcarPesquisaPorNome(texto: string) {
    if (!texto) {
      return;
    }
    else {
      this.termoPesquisa = texto;
      this.listarPorNome(1);
    }
  }

  tipoCatalogo: EnumCatalogo;
  categoria: number;
  promocao: number;
  termoPesquisa: string;
  pager: any = {};
  produtos: Listagem<ProdutoCatalogo>;
}
