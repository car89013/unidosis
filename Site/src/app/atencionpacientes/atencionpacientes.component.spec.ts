import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AtencionPacientesComponent } from './atencionpacientes.component';


describe('PrescipcionComponent', () => {
  let component: AtencionPacientesComponent;
  let fixture: ComponentFixture<AtencionPacientesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AtencionPacientesComponent ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AtencionPacientesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
