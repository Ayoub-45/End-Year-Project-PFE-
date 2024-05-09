import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelatedPatientComponent } from './related-patient.component';

describe('RelatedPatientComponent', () => {
  let component: RelatedPatientComponent;
  let fixture: ComponentFixture<RelatedPatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RelatedPatientComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RelatedPatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
