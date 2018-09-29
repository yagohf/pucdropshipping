import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS  } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { CatalogoComponent } from './catalogo/catalogo.component';
import { CategoriasComponent } from './categorias/categorias.component';
import { HomeComponent } from './home/home.component';
import { PedidosComponent } from './pedidos/pedidos.component';
import { MaisvendidosComponent } from './maisvendidos/maisvendidos.component';
import { PromocoesComponent } from './promocoes/promocoes.component';
import { PropagandasComponent } from './propagandas/propagandas.component';
import { AppRoutingModule } from './_routing/app-routing.module';
import { AppNgxbootsbundleModule } from './_ngxbundle/app-ngxbootsbundle.module';
import { AcesseComponent } from './acesse/acesse.component';
import { ProdutoComponent } from './produto/produto.component';

import { AuthenticationService } from './_services/authentication.service';
import { AuthGuard } from './_guards/auth.guard';
import { AuthInterceptor } from './_interceptors/auth.interceptor';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { MensagensComponent } from './mensagens/mensagens.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    CatalogoComponent,
    CategoriasComponent,
    PedidosComponent,
    HomeComponent,
    MaisvendidosComponent,
    PromocoesComponent,
    PropagandasComponent,
    AcesseComponent,
    ProdutoComponent,
    MensagensComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AppNgxbootsbundleModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AuthGuard, AuthenticationService,  
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
