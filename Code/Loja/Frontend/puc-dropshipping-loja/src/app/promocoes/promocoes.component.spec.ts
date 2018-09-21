import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PromocoesComponent } from './promocoes.component';

describe('PromocoesComponent', () => {
  let component: PromocoesComponent;
  let fixture: ComponentFixture<PromocoesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PromocoesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PromocoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
