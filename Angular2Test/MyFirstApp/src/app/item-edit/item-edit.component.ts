import { Component } from '@angular/core';
import { Input, Output, EventEmitter } from '@angular/core';
import { Item } from '../Models';
import { ItemCategory } from '../Models';
import { ItemService }  from '../ItemService';

@Component({
    selector: 'ItemEdit',
    templateUrl: './item-edit.component.html',
    styleUrls: ['./item-edit.component.css'],
    providers: [ItemService]    
})
export class ItemEditComponent  {
    @Input() CrItem: Item;
    @Output() Saved = new EventEmitter<Item>();
    @Input() Opration: string;

    public ItemCategorys: ItemCategory[];

    constructor(private itemService: ItemService) {
        this.ItemCategorys = itemService.getItemCategorys();
    }

    SaveItem() {
        console.log('SaveItem');
        console.log(this.CrItem);
        this.Saved.emit(this.CrItem);
    }

    btnCancel_Click() {
        console.log('btnCancel_Click');
        this.Saved.emit(null);
    }

    drpItemCategoryId_Change(event: any) {
        console.log('drpItemCategoryId_Change');
        console.log(event[event.selectedIndex].attributes.categoryname);
        //console.log(event);
    }
}
