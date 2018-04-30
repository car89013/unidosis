import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrescipcionComponent } from './atencionpacientes.component';

describe('PrescipcionComponent', () => {
  let component: PrescipcionComponent;
  let fixture: ComponentFixture<PrescipcionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrescipcionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrescipcionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
