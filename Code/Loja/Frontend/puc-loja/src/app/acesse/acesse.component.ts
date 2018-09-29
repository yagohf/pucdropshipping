import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_services/authentication.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Login } from '../_models/login';
import { Router, ActivatedRoute } from '@angular/router';
import { MensagensService } from '../_services/mensagens.service';
import { EnumMensagem } from '../_models/enums/enum.mensagem';

@Component({
  selector: 'app-acesse',
  templateUrl: './acesse.component.html',
  styleUrls: ['./acesse.component.css']
})
export class AcesseComponent implements OnInit {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authenticationService: AuthenticationService,
    private formBuilder: FormBuilder,
    private mensagemService: MensagensService) { }

  ngOnInit() {
    this.formLogin = this.formBuilder.group({
      usuario: ['', Validators.required],
      senha: ['', Validators.required]
    });

    //Setar URL de retorno após o login.
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  //Getter para facilitar acesso aos controles.
  get f() { return this.formLogin.controls; }

  submeterLogin() {
    this.submitted = true;

    if (this.formLogin.invalid) {
      return;
    }

    let login: Login = {
      usuario: this.f.usuario.value,
      senha: this.f.senha.value
    };

    this.authenticationService.login(login)
      .subscribe(
        resultado => {
          if (resultado.status == 1) {
            console.log(this.returnUrl);
            this.router.navigate([this.returnUrl]);
          }
          else if(resultado.status == 2) {
            this.mensagemService.enviarMensagem('Usuário ou senha inválidos.', EnumMensagem.ERRO);
          }
        },
        error => {
          console.log(error);
        });
  }

  formLogin: FormGroup;
  returnUrl: string;
  submitted: boolean = false;
}
