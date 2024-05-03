import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelatedDoctorComponent } from './related-doctor.component';

describe('RelatedDoctorComponent', () => {
  let component: RelatedDoctorComponent;
  let fixture: ComponentFixture<RelatedDoctorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RelatedDoctorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RelatedDoctorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
