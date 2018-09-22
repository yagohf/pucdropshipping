import { Component, OnInit } from '@angular/core';
import { Promocao } from '../_models/promocao';
import { PromocoesService } from '../_services/promocoes.service';

@Component({
  selector: 'app-promocoes',
  templateUrl: './promocoes.component.html',
  styleUrls: ['./promocoes.component.css']
})
export class PromocoesComponent implements OnInit {

  constructor(private promocoesService: PromocoesService) { }

  ngOnInit() {
    this.listar();
  }

  listar() {
    this.promocoesService.listar().subscribe(retorno => this.promocoes = retorno);
  }

  promocoes: Promocao[];
}
