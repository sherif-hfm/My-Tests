import { Component, OnInit } from '@angular/core';
import { Item } from '../Models';
import { ItemCategory } from '../Models';
import { ItemService }  from '../ItemService';
import { NgTemplateOutlet } from '@angular/common';
import {  ViewChild,ContentChild, AfterViewInit, AfterContentInit, Query, QueryList, ViewChildren, ContentChildren, TemplateRef} from '@angular/core';
@Component({
  selector: 'dropdown-list-test',
  templateUrl: './dropdown-list-test.component.html',
  styleUrls: ['./dropdown-list-test.component.css'],
  providers: [ItemService],
})
export class DropdownListTestComponent implements OnInit {

  public items: Item[];
  public ItemCategorys: ItemCategory[];

  constructor(private itemService: ItemService) {
    this.ItemCategorys = itemService.getItemCategorys();
    this.items = itemService.getItems();
   }
  
  ngOnInit() {
  }

  item_click(item:any )
  {
    console.log('Client');
    console.log(item);
  }

}
