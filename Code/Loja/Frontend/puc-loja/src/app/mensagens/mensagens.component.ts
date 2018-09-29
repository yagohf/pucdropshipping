import { Component, OnInit } from '@angular/core';
import { MensagensService } from '../_services/mensagens.service';
import { Subscription } from 'rxjs';
import { EnumMensagem } from '../_models/enums/enum.mensagem';
import { Guid } from '../_models/infraestrutura/guid';

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
        let novaMsg = { id: Guid.newGuid(), texto: msg.texto, tipo: msg.tipo };
        this.mensagens.push(novaMsg);
        var this$ = this;
        setTimeout(function () {
          this$.removerMensagem(novaMsg.id);
        }, 3000);
      }
    });
  }

  removerMensagem(id: string) {
    var mensagemRemover = this.mensagens.find(x => x.id === id);
    if (mensagemRemover) {
      this.mensagens.splice(this.mensagens.indexOf(mensagemRemover), 1);
    }
  }

  mensagens: any[] = [];
}
