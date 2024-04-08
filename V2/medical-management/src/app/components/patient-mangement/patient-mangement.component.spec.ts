import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientMangementComponent } from './patient-mangement.component';

describe('PatientMangementComponent', () => {
  let component: PatientMangementComponent;
  let fixture: ComponentFixture<PatientMangementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PatientMangementComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PatientMangementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
