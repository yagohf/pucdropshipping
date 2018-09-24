import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_services/authentication.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Login } from '../_models/login';
import { Router, ActivatedRoute } from '@angular/router';

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
    private formBuilder: FormBuilder) { }

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
      // .pipe(first())
      .subscribe(
        data => {
          console.log(this.returnUrl);
          this.router.navigate([this.returnUrl]);
        },
        error => {
          console.log(error);
        });
  }

  formLogin: FormGroup;
  returnUrl: string;
  submitted: boolean = false;
}
