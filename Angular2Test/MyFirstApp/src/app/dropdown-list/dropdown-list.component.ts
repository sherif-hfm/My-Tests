import { Component, ViewChild,ContentChild, AfterViewInit, AfterContentInit, Query, QueryList, ViewChildren, ContentChildren, OnInit ,TemplateRef} from '@angular/core';
import { Input, Output, EventEmitter,ElementRef } from '@angular/core';


@Component({
  selector: 'dropdown-list',
  templateUrl: './dropdown-list.component.html',
  styleUrls: ['./dropdown-list.component.css']
})
export class DropdownListComponent implements OnInit ,AfterViewInit,AfterContentInit {

  @Input() dataSource: [any];
  @Input() dataTextField: string;
  @Input() dataValueField: string;

  public mDataSource ; 
  public SelectedItem; 

  @Output()  ItemClicked: EventEmitter<number> = new EventEmitter<number>();

  @ContentChild(TemplateRef)   template: any;
  @ViewChild('dropFilter')   dropFilter : ElementRef ;
  @ViewChild('selectText')   selectText : ElementRef ;
  public openDropDown: boolean = false;

  

  constructor() {
    
   }

  ngOnInit() {
    this.mDataSource=Array.from(this.dataSource) ;
  }
  ngAfterContentInit() {
    console.log('ngAfterContentInit');
    setTimeout(() => { console.log('templates :' + this.template) }, 0);
}
  ngAfterViewInit() {
    console.log('ngAfterViewInit');
    setTimeout(() => { console.log('templates :' + this.template) }, 0);
    setTimeout(() => { console.log('dropFilter :' + this.dropFilter) }, 0);
    setTimeout(() => { console.log('selectText :' + this.selectText) }, 0);
  }

  item_click(item:any )
  {
    console.log('item_click');
    console.log('Item Name : ' + item.ItemName);
    this.SelectedItem=item;
    this.ItemClicked.emit(item);
  }
  OpenDropDown_click()
  {
    console.log('OpenDropDown_click');
    console.log(this.dropFilter)    
    this.openDropDown=true;
    
    setTimeout(() => {
      this.dropFilter.nativeElement.focus(); }, 1);
  }

  mouseleave(){
    console.log('mouseleave');
    this.openDropDown=false;
  }

  filter_keypress(e)
  {
    //this.mDataSource = this.dataSource.filter(i=>i[this.dataTextField].includes(e.target.value));;
    this.mDataSource = this.dataSource.filter(i=>i[this.dataTextField].includes(e.value));;
    console.log('filter_Change');
    console.log(e.value);
  }

}
