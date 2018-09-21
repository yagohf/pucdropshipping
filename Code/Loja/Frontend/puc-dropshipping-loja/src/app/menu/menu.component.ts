import { Component, HostListener } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
  animations: [
    trigger('collapse', [
      state('open', style({
        opacity: '1'
      })),
      state('closed', style({
        opacity: '0',
        display: 'none',
      })),
      transition('closed => open', animate('400ms ease-in')),
      transition('open => closed', animate('100ms ease-out'))
    ])
  ]
})
export class MenuComponent {
  title = 'puc-dropshipping-loja';
  isNavbarCollapsed = true;
  _isNavbarCollapsedAnim = 'closed';
  ngOnInit() {
    this.onResize(window);
  }
  @HostListener('window:resize', ['$event.target'])
  onResize(event) {
    if (event.innerWidth > 990) {
      // Setar essa opção para telas grandes por causa da opacidade na animação.
      this._isNavbarCollapsedAnim = 'open';
      this.isNavbarCollapsed = true;
    } else {
      // Comentar essa linha se não for necessário mudar collapsar o menu quando a janela mudar de tamanho.
      // this._isNavbarCollapsedAnim = 'closed';
    }
  }
  toggleNavbar(): void {
    if (this.isNavbarCollapsed) {
      this._isNavbarCollapsedAnim = 'open';
      this.isNavbarCollapsed = false;
    } else {
      this._isNavbarCollapsedAnim = 'closed';
      this.isNavbarCollapsed = true;
    }
  }
  get isNavbarCollapsedAnim(): string {
    return this._isNavbarCollapsedAnim;
  }
}