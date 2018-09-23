import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
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
    ProdutoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AppNgxbootsbundleModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
