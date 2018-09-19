import { TestBed, inject } from '@angular/core/testing';

import { CheckLoginService } from './check-login.service';

describe('CheckLoginService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CheckLoginService]
    });
  });

  it('should ...', inject([CheckLoginService], (service: CheckLoginService) => {
    expect(service).toBeTruthy();
  }));
});
