import { Component, OnInit } from '@angular/core';
import { Produto } from '../_models/produto';
import { ProdutosService } from '../_services/produtos.service';
import { ActivatedRoute } from '@angular/router';
import { Listagem } from '../_models/infraestrutura/listagem';
import { PagerService } from '../_services/pager.service';
import { Paginacao } from '../_models/infraestrutura/paginacao';
import { EnumCatalogo } from '../_models/enums/enumcatalogo';

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
    });
  }

  listarPorCategoria(pagina: number) {
    this.produtosService.listarPorCategoria(this.categoria, pagina).subscribe(retorno => {
      this.produtos = retorno;
      this.atualizarPager(retorno.paginacao);
    });
  }

  atualizarPager(paginacao: Paginacao) {
    this.pager = this.pagerService.getPager(paginacao.totalRegistros, paginacao.paginaAtual);
  }

  setPage(p: number) {
    switch (this.tipoCatalogo) {
      case EnumCatalogo.CATEGORIA:
        this.listarPorCategoria(p);
        break;
      default:
        console.log('Impossível paginar com os critérios informados.');
        break;
    }
  }

  tipoCatalogo: EnumCatalogo;
  categoria: number;
  promocao: number;
  termoPesquisa: string;
  pager: any = {};
  produtos: Listagem<Produto>;
}
