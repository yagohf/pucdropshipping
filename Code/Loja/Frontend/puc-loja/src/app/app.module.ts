import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { CatalogoComponent } from './catalogo/catalogo.component';
import { CategoriasComponent } from './categorias/categorias.component';
import { ComprasComponent } from './compras/compras.component';
import { VendasComponent } from './vendas/vendas.component';
import { HomeComponent } from './home/home.component';
import { MaisvendidosComponent } from './maisvendidos/maisvendidos.component';
import { PromocoesComponent } from './promocoes/promocoes.component';
import { PropagandasComponent } from './propagandas/propagandas.component';
import { AppRoutingModule } from './app-routing.module';
import { AppNgxbootsbundleModule } from './app-ngxbootsbundle.module';
import { AcesseComponent } from './acesse/acesse.component';
import { ProdutoComponent } from './produto/produto.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    CatalogoComponent,
    CategoriasComponent,
    ComprasComponent,
    VendasComponent,
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
    AppNgxbootsbundleModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
