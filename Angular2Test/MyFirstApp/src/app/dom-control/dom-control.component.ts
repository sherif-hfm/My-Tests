import { Component,  ViewChild, AfterViewInit, AfterContentInit, Query, QueryList, ViewChildren, ContentChildren,Renderer2 } from '@angular/core';

@Component({
    selector: 'DomControl',
    templateUrl: './dom-control.component.html',
    styleUrls: ['./dom-control.component.css'],
})
export class DomControlComponent implements AfterViewInit, AfterContentInit  {

    @ViewChildren('button') childs: QueryList<any>;  
    @ViewChildren('alertbox1') alertbox1: QueryList<any>;  
        

    public AlertBox: any;
    public alertBoxShow: boolean = false;
    public btnShow: boolean = false;
    
    constructor(private rd: Renderer2) {
        console.log('DomControlComponent constructor');
        console.log(this.rd);
    }

    ngAfterContentInit() {
        console.log('DomControlComponent ngAfterContentInit');
    }

    ngAfterViewInit() {
        console.log('DomControlComponent ngAfterViewInit');
        console.log(this.childs);
        console.log(this.childs.first);
        console.log('alertbox1');
        console.log(this.alertbox1);
        this.alertbox1.changes.subscribe(() => { console.log('alertbox1 change'); console.log(this.alertbox1); this.AlertBox = this.alertbox1.first ; }); // to check if any changes happend in childs like if new items showen
        this.childs.changes.subscribe(() => { console.log('childs change');console.log(this.childs) }); // to check if any changes happend in childs like if new items showen
        //this.AlertBox = this.alertbox1;
    }

    btn_Click() {
        console.log('btn_Click');
        this.btnShow = true;
        this.alertBoxShow = true;
        //var btns = window.document.getElementsByTagName('button'); // get all button tag even outside the component
        //btns[0].textContent = "OK";
        //console.log(window.document.getElementsByTagName('button'));
        
        //this.childs.first.nativeElement.textContent="Get Buttons2";
        //this.alertBoxShow = true;
    }

    btn_ShowAlert()
    {
        this.AlertBox.Show();
    }

    AlertBoxOnInit(_alertBox) {
        console.log('AlertBoxInit');
        console.log(_alertBox);
        //this.AlertBox = _alertBox;
    }
}
