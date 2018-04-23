import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EnfermerasComponent } from './enfermeras.component';

describe('EnfermerasComponent', () => {
  let component: EnfermerasComponent;
  let fixture: ComponentFixture<EnfermerasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EnfermerasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnfermerasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
