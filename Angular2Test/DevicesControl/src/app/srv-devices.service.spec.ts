import { TestBed, inject } from '@angular/core/testing';

import { SrvDevicesService } from './srv-devices.service';

describe('SrvDevicesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SrvDevicesService]
    });
  });

  it('should ...', inject([SrvDevicesService], (service: SrvDevicesService) => {
    expect(service).toBeTruthy();
  }));
});
