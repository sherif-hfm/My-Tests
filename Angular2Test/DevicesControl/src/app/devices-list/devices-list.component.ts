import { Component, OnInit } from '@angular/core';
import { Device } from '../device-model';
import { SrvDevicesService }  from '../srv-devices.service';
@Component({
  selector: 'devicesList',
  templateUrl: './devices-list.component.html',
  styleUrls: ['./devices-list.component.css'],
  providers: [SrvDevicesService],
})
export class DevicesListComponent implements OnInit {

  public Devices: Device[];
  constructor(private devicesService: SrvDevicesService) {
    this.loadDevices();
   }

  ngOnInit() {
  }

  loadDevices()
  {
    this.devicesService.getDevices().subscribe(data => {
      this.Devices=data;
    });
  }

  btnOn_Click(device: Device)
  {
    console.log(device.DeviceName + " on");
    this.devicesService.setDeviceStatus(device.DeviceId , "1").subscribe(()=>{
      console.log('ok');
      this.loadDevices();
    });
  }

  btnOff_Click(device: Device)
  {
    console.log(device.DeviceName + " off");
    this.devicesService.setDeviceStatus(device.DeviceId , "0").subscribe(()=>{
      console.log('ok');
      this.loadDevices();
    });
  }

}
