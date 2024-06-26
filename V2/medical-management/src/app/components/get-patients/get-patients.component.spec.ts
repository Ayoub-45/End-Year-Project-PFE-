import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetPatientsComponent } from './get-patients.component';

describe('GetPatientsComponent', () => {
  let component: GetPatientsComponent;
  let fixture: ComponentFixture<GetPatientsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetPatientsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetPatientsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
