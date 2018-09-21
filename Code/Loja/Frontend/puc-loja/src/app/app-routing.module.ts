import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CatalogoComponent } from './catalogo/catalogo.component';
import { ComprasComponent } from './compras/compras.component';
import { VendasComponent } from './vendas/vendas.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent},
  // { path: 'acesse', component: AcesseComponent},
  { path: 'catalogo', component: CatalogoComponent },
  { path: 'compras', component: ComprasComponent },
  { path: 'vendas', component: VendasComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}