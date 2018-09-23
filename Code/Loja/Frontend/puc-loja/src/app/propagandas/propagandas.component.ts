import { Component, OnInit } from '@angular/core';
import { PropagandasService } from '../_services/propagandas.service';
import { Propaganda } from '../_models/propaganda';

@Component({
  selector: 'app-propagandas',
  templateUrl: './propagandas.component.html',
  styleUrls: ['./propagandas.component.css']
})
export class PropagandasComponent implements OnInit {

  constructor(private propagandasService: PropagandasService) { }

  ngOnInit() {
    this.listar();
  }

  listar() {
    this.propagandasService.listar().subscribe(retorno => this.propagandas = retorno);
  }

  redirecionar(url: string) {
    var urlBase = document.location.href.split('/')[0];
    document.location.href = urlBase + url;
  }

  propagandas: Propaganda[];
}
