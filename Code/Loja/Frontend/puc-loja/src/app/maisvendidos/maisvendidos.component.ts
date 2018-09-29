import { Component, OnInit } from '@angular/core';
import { ProdutoCatalogo } from '../_models/produtocatalogo';
import { ProdutosService } from '../_services/produtos.service';

@Component({
  selector: 'app-maisvendidos',
  templateUrl: './maisvendidos.component.html',
  styleUrls: ['./maisvendidos.component.css']
})
export class MaisvendidosComponent implements OnInit {

  constructor(private produtoService: ProdutosService) { }

  ngOnInit() {
    this.listar();
  }

  listar() {
    this.produtoService.listarMaisVendidos().subscribe(retorno => this.produtos = retorno);
  }

  produtos: ProdutoCatalogo[];
}
