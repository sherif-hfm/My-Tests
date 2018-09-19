import { Component, ViewChild, AfterViewInit, AfterContentInit, Query, QueryList, ViewChildren, ContentChildren } from '@angular/core';
import { ChildTestComponent } from '../child-test/child-test.component';
@Component({
    selector: 'QueryTest',
    templateUrl: './query-test.component.html',
    styleUrls: ['./query-test.component.css'],
    providers: [ QueryList],
})
export class QueryTestComponent implements AfterViewInit, AfterContentInit {

    public selected: boolean=true;

    @ViewChildren('ChildTest1') childs: QueryList<any>;  // to find by using #ChildTest

    @ContentChildren('ChildTest3') childs2: QueryList<any>; // to find by using #ChildTest

    @ViewChild(ChildTestComponent) child: ChildTestComponent;
   // @ViewChild('ChildTest2') child: ChildTestComponent;

   @ViewChildren(ChildTestComponent) children: QueryList<ChildTestComponent>;
    
    @ContentChildren(ChildTestComponent) childs3: QueryList<ChildTestComponent>;

    ngAfterContentInit() {
        console.log('ngAfterContentInit');
        
    }

    ngAfterViewInit() {
        console.log('ngAfterViewInit');
        /*
        console.log('child2' + this. child);
        setTimeout(() => { this. child.UpdateValue("My Data3"); }, 0);
        
        console.log('child3' + this. childs3);
        setTimeout(() => { this.childs3.first.UpdateValue("My Data4"); }, 0);

        console.log('ViewChildren');
        console.log(this.childs);
        console.log("childs[0]" + this.childs.first);
        //setTimeout(() => { this.childs.first.UpdateValue("My Data2"); }, 0);

        console.log('ContentChildren');
        console.log(this.childs2);
        //setTimeout(() => { this.childs2.first.UpdateValue("My Data3"); }, 0);
*/
    }

    btnChange_click(){
        console.log('btnChange_click');
        console.log('CtrlName:' + this.child.CtrlName );
        this.selected=!this.selected;
    }

    btnUpdate_click(){
        console.log('btnChange_update');
        console.log('CtrlName:' + this.child.CtrlName );
        this.child.UpdateValue("Data5");
    }

    btnUpdateAll_click(){
        console.log('btnChange_update');
        this.children.forEach(c=> c.UpdateValue("UpdateAll"));
    }
}
