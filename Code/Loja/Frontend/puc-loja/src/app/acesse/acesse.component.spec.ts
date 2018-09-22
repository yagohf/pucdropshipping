import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AcesseComponent } from './acesse.component';

describe('AcesseComponent', () => {
  let component: AcesseComponent;
  let fixture: ComponentFixture<AcesseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AcesseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AcesseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
