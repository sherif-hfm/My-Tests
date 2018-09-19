import { Injectable } from '@angular/core';
import { Device } from './device-model';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/observable';


@Injectable()
export class SrvDevicesService {
  
  constructor(private http: HttpClient) {
   }
  
  getDevices() {
    //console.log('getDevices');  
    let Devices: Device[];
    return this.http.get<Device[]>('http://45.35.4.147:6010/RegsApi/GetDevicesList');
  }

  setDeviceStatus(did: string,ds: string)
  {
    var url="http://45.35.4.147:6010/RegsApi/SetDeviceStatus/"+ did +"/"+ ds +"/";
    //console.log(url);
    return this.http.get(url);
  }
}
