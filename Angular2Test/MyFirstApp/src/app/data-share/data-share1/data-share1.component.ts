import { Component, OnInit } from '@angular/core';
import { DataShareService }  from '../../data-share.service';
@Component({
  selector: 'app-data-share1',
  templateUrl: './data-share1.component.html',
  styleUrls: ['./data-share1.component.css'],
  providers:[]
})
export class DataShare1Component implements OnInit {
  public myVar1: string=" "
  constructor(private dataShareService: DataShareService) { 
    
  }

  ngOnInit() {
    this.dataShareService.crMyVar1.subscribe(v => this.myVar1 = v)
  }

  button1_click()
  {
    console.log('button1_click');
    DataShareService.myVar2 = DataShareService.myVar2+ "A"
    console.log(DataShareService.myVar2);
    this.dataShareService.setMyVal1(this.myVar1 + " A ");
  }

}
