import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaisvendidosComponent } from './maisvendidos.component';

describe('MaisvendidosComponent', () => {
  let component: MaisvendidosComponent;
  let fixture: ComponentFixture<MaisvendidosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaisvendidosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaisvendidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
