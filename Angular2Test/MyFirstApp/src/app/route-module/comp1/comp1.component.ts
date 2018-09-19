import { Component, OnInit } from '@angular/core';
import {jsTest} from './comp1.js';
@Component({
  selector: 'Comp1',
  templateUrl: './comp1.component.html',
  styleUrls: ['./comp1.component.css']
})
export class Comp1Component implements OnInit {

  constructor() { 
var myjsTest :any=new jsTest();
    
  }

  ngOnInit() {
  }


}
