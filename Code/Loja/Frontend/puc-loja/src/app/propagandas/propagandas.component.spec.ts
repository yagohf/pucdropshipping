import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PropagandasComponent } from './propagandas.component';

describe('PropagandasComponent', () => {
  let component: PropagandasComponent;
  let fixture: ComponentFixture<PropagandasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PropagandasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PropagandasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
