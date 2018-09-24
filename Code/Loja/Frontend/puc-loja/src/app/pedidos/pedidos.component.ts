import { Component, OnInit } from '@angular/core';
import { Compra } from '../_models/compra';
import { Venda } from '../_models/venda';
import { PedidosService } from '../_services/pedidos.service';
import { AuthenticationService } from '../_services/authentication.service';
import { EnumPerfil } from '../_models/enums/enum.perfil';
import { Listagem } from '../_models/infraestrutura/listagem';
import { PagerService } from '../_services/pager.service';
import { Paginacao } from '../_models/infraestrutura/paginacao';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {

  constructor(private pedidosService: PedidosService, private authenticationService: AuthenticationService, private pagerService: PagerService) { }

  ngOnInit() {
    this.exibirCompras = this.authenticationService.verificarPermissao(EnumPerfil.CLIENTE);
    this.exibirVendas = this.authenticationService.verificarPermissao(EnumPerfil.VENDEDOR);

    if (this.exibirCompras) {
      this.listarCompras(1);
    }

    if (this.exibirVendas) {
      this.listarVendas(1);
    }
  }

  listarCompras(pagina: number) {
    var usuarioLogado = this.authenticationService.obterUsuarioLogado();
    this.pedidosService.listarCompras(usuarioLogado, pagina).subscribe(retorno => {
      this.compras = retorno;
      this.atualizarPagerCompras(retorno.paginacao);
    });
  }

  listarVendas(pagina: number) {
    var usuarioLogado = this.authenticationService.obterUsuarioLogado();
    this.pedidosService.listarVendas(usuarioLogado, pagina).subscribe(retorno => {
      this.vendas = retorno;
      this.atualizarPagerVendas(retorno.paginacao);
    });
  }

  atualizarPagerCompras(paginacao: Paginacao) {
    this.pagerCompras = this.pagerService.getPager(paginacao.totalRegistros, paginacao.paginaAtual);
  }

  atualizarPagerVendas(paginacao: Paginacao) {
    this.pagerVendas = this.pagerService.getPager(paginacao.totalRegistros, paginacao.paginaAtual);
  }

  setPageCompras(p: number, desabilitado: boolean) {
    if (desabilitado) {
      return;
    }

    this.listarCompras(p);
  }

  setPageVendas(p: number, desabilitado: boolean) {
    if (desabilitado) {
      return;
    }

    this.listarVendas(p);
  }

  exibirCompras: boolean;
  exibirVendas: boolean;
  compras: Listagem<Compra>;
  vendas: Listagem<Venda>;
  pagerCompras: any = {};
  pagerVendas: any = {};
}
