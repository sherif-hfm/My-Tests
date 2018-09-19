import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'alert-box',
  templateUrl: './alert-box.component.html',
  styleUrls: ['./alert-box.component.css']
})
export class AlertBoxComponent implements OnInit {

    @Output() AlertBoxOnInit = new EventEmitter<AlertBoxComponent>();

    public DisplayStatus: string = "none";

    constructor() {
        console.log("AlertBox constructor")
        
    }

    public Show() {
        this.DisplayStatus = "flex";
    }

    ngOnInit() {
        console.log("AlertBox ngOnInit");
        console.log("AlertBox emit");
        console.log(this);
        this.AlertBoxOnInit.emit(this);
  }
}
