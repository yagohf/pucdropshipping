import { Component, OnInit } from '@angular/core';
import { Produto } from '../_models/produto';
import { ProdutosService } from '../_services/produtos.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-catalogo',
  templateUrl: './catalogo.component.html',
  styleUrls: ['./catalogo.component.css']
})
export class CatalogoComponent implements OnInit {

  constructor(private route: ActivatedRoute, private produtosService: ProdutosService) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (params['categoria']) {
        this.listarPorCategoria(parseInt(params['categoria']));
      }
    });
  }

  listarPorCategoria(categoria: number) {
    this.produtosService.listarPorCategoria(categoria).subscribe(retorno => this.produtos = retorno);
  }

  termoPesquisa: string = "Tênis";
  produtos: Produto[];
}
