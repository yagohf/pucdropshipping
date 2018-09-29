import { Component, OnInit } from '@angular/core';
import { MensagensService } from '../_services/mensagens.service';
import { Subscription } from 'rxjs';
import { EnumMensagem } from '../_models/enums/enum.mensagem';

@Component({
  selector: 'app-mensagens',
  templateUrl: './mensagens.component.html',
  styleUrls: ['./mensagens.component.css']
})
export class MensagensComponent implements OnInit {
  subscription: Subscription;
  private tiposMensagens = EnumMensagem; //Associar membro ao ENUM para poder bindar no template.

  constructor(private mensagensService: MensagensService) { }

  ngOnInit() {
    this.subscription = this.mensagensService.getMensagens().subscribe(msg => {
      if (!this.mensagens.find(x => x.texto == msg.texto)) {
        this.mensagens.push({ texto: msg.texto, tipo: msg.tipo });
      }
    });
  }

  removerMensagem(indice: number) {
    this.mensagens.splice(indice, 1);
  }

  mensagens: any[] = [];
}
