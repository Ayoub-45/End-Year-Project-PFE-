import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPatientdetailsComponent } from './add-patientdetails.component';

describe('AddPatientdetailsComponent', () => {
  let component: AddPatientdetailsComponent;
  let fixture: ComponentFixture<AddPatientdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddPatientdetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddPatientdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
