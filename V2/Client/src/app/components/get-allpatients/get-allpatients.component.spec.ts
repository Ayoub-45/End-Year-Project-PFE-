import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetAllpatientsComponent } from './get-allpatients.component';

describe('GetAllpatientsComponent', () => {
  let component: GetAllpatientsComponent;
  let fixture: ComponentFixture<GetAllpatientsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetAllpatientsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetAllpatientsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
