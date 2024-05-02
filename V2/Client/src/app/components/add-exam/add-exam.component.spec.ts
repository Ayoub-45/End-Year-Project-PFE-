import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddExamComponent } from './add-exam.component';

describe('AddExamComponent', () => {
  let component: AddExamComponent;
  let fixture: ComponentFixture<AddExamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddExamComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddExamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
