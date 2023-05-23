import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BulkAddDriverComponent } from './bulk-add-driver.component';

describe('BulkAddDriverComponent', () => {
  let component: BulkAddDriverComponent;
  let fixture: ComponentFixture<BulkAddDriverComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BulkAddDriverComponent]
    });
    fixture = TestBed.createComponent(BulkAddDriverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
