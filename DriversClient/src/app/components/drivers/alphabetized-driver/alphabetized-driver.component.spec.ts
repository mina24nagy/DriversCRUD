import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlphabetizedDriverComponent } from './alphabetized-driver.component';

describe('AlphabetizedDriverComponent', () => {
  let component: AlphabetizedDriverComponent;
  let fixture: ComponentFixture<AlphabetizedDriverComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlphabetizedDriverComponent]
    });
    fixture = TestBed.createComponent(AlphabetizedDriverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
