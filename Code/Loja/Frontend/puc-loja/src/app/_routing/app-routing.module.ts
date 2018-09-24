import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CatalogoComponent } from '../catalogo/catalogo.component';
import { HomeComponent } from '../home/home.component';
import { AcesseComponent } from '../acesse/acesse.component';
import { PedidosComponent } from '../pedidos/pedidos.component';
import { AuthGuard } from '../_guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent},
  { path: 'acesse', component: AcesseComponent },
  { path: 'catalogo', component: CatalogoComponent },
  { path: 'pedidos', component: PedidosComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}