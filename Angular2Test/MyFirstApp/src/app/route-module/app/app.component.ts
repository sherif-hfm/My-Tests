import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

public link1: string = "/comp1";

  constructor() { }

  ngOnInit() {
  }

  btn_click(){
      console.log('btn_click');
      this.link1="/comp2";
    }

}
