import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { PropagandasComponent } from './propagandas/propagandas.component';
import { PromocoesComponent } from './promocoes/promocoes.component';
import { HomeComponent } from './home/home.component';
import { CatalogoComponent } from './catalogo/catalogo.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    PropagandasComponent,
    PromocoesComponent,
    HomeComponent,
    CatalogoComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
