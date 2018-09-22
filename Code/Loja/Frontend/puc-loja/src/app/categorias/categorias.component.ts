import { Component, OnInit } from '@angular/core';
import { Categoria } from '../_models/categoria';
import { CategoriasService } from '../_services/categorias.service';

@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent implements OnInit {

  constructor(private categoriaService: CategoriasService) { }

  ngOnInit() {
    this.listar();
  }

  listar() {
    this.categoriaService.listar().subscribe(retorno => this.categorias = retorno);
  }

  categorias: Categoria[];
}
