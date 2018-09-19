import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';

import { ItemService }         from './ItemService';
import { DataShareService }  from './data-share.service';

import { AppComponent }  from './app.component';
import { DataBindingComponent }  from './data-binding/data-binding.component';
import {  ItemsListComponent }  from './items-list/items-list.component';
import {  ItemEditComponent }  from './item-edit/item-edit.component';
import {  QueryTestComponent }  from './query-test/query-test.component';
import {  ChildTestComponent }  from './child-test/child-test.component';
import { AlertBoxComponent } from './alert-box/alert-box.component';
import {  DomControlComponent }  from './dom-control/dom-control.component';
import { Directive1Directive } from './directive1/directive1.directive';
import { Form1Component } from './form1/form1.component';
import { Test1Component } from './test1/test1.component';
import { DropdownListComponent } from './dropdown-list/dropdown-list.component';
import { DropdownListTestComponent } from './dropdown-list-test/dropdown-list-test.component';
import { DirectiveTestComponent } from './directive1/directive-test/directive-test.component';
import { BasicHighlightDirective } from './directives/basic-highlight.directive';
import { DataShareComponent } from './data-share/data-share/data-share.component';
import { DataShare1Component } from './data-share/data-share1/data-share1.component';
import { DataShare2Component } from './data-share/data-share2/data-share2.component';

@NgModule({
    imports: [BrowserModule, FormsModule ],
    declarations: [AppComponent, DataBindingComponent, ItemsListComponent, ItemEditComponent, QueryTestComponent, ChildTestComponent, DomControlComponent, AlertBoxComponent,
    Directive1Directive, Form1Component, Test1Component, DropdownListComponent, DropdownListTestComponent, DirectiveTestComponent, BasicHighlightDirective, DataShareComponent, DataShare1Component, DataShare2Component],   
    providers:[DataShareService],
  bootstrap: [AppComponent ]
})
export class AppModule { } 
