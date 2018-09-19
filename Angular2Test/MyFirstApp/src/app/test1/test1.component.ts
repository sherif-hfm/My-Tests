import { Component, OnInit, AfterViewInit, Renderer2, ViewChildren, QueryList, ElementRef, ViewContainerRef } from '@angular/core';

import './test.js';
declare var myExtObject: any;

@Component({
  selector: 'test1',
  templateUrl: './test1.component.html',
  styleUrls: ['./test1.component.css']
})
export class Test1Component implements OnInit, AfterViewInit  { 

    constructor(private rd: Renderer2, private _el: ElementRef, private vc: ViewContainerRef) {
        console.log('Test1Component constructor');
        console.log(this.rd); 
        console.log(this.vc); 
    }

  ngOnInit() {
            
      console.log('Test1Component ngOnInit'); 
  }
 
  ngAfterViewInit() {
      console.log('Test1Component ngAfterViewInit');
  }

  btn_ckick()
  {
      this.rd.createElement('button', this._el.nativeElement);
      //console.log(btn);
  }
}
