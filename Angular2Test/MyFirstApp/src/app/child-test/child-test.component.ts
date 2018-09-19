import { Component } from '@angular/core';
import { Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'ChildTest',
    templateUrl: './child-test.component.html',
    styleUrls: ['./child-test.component.css']
})
export class ChildTestComponent  {
    public Data: string;
    @Input() CtrlName: string;

    constructor() {
        
    }

    public UpdateValue(newData: string) {
        this.Data = newData;
        console.log('CtrlName=' + this.CtrlName);
    }
}
