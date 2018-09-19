import { Component, OnInit } from '@angular/core';
import { DataShareService }  from '../../data-share.service';

@Component({
  selector: 'app-data-share2',
  templateUrl: './data-share2.component.html',
  styleUrls: ['./data-share2.component.css'],
  providers:[]
})
export class DataShare2Component implements OnInit {
  public myVar1: string=" "
  constructor(private dataShareService: DataShareService) {
    

   }

  ngOnInit() {
    this.dataShareService.crMyVar1.subscribe(v => this.myVar1 = v)
  }

  button2_click()
  {
    console.log('button2_click');
    DataShareService.myVar2 = DataShareService.myVar2+ "B"
    console.log(DataShareService.myVar2);
    this.dataShareService.setMyVal1(this.myVar1 + " B ");
  }

}
