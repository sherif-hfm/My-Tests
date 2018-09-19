import { Component } from '@angular/core';
import { Item } from '../Models';
import { ItemCategory } from '../Models';
import { ItemService }  from '../ItemService';
// import { ItemEditComponent }  from './ItemEdit';

@Component({
    selector: 'ItemsList',
    templateUrl: './items-list.component.html',
    styleUrls: ['./items-list.component.css'],
    providers: [ItemService],
})
export class ItemsListComponent  {

    public items: Item[];
    public CrItem: Item = new Item();
    public ItemCategorys: ItemCategory[];
    public Opration: string = "List";
    submitted = false;
    
       

    constructor(private itemService: ItemService ) {
        console.log('constructor');
        this.ItemCategorys = itemService.getItemCategorys();
        this.items = itemService.getItems();
    }

    

    SaveItem(item: Item) {        
        console.log('SaveItem' + item);
        if (item != null) {
            console.log(item);
            this.itemService.saveItem(item);
        }
        this.Opration = "List";
    }

    btnAddItem_Click() {
        console.log('btnAddItem_Click ');
        this.CrItem = new Item();
        this.Opration = "Add";
    }

    btnEditItem_Click(_Item: Item) {
        console.log('btnEditItem_Click ' + _Item.ItemId);
        this.CrItem = new Item();
        this.CrItem.ItemId = _Item.ItemId;
        this.CrItem.ItemName = _Item.ItemName;
        this.CrItem.ItemPrice = _Item.ItemPrice;
        this.CrItem.ItemQuantity = _Item.ItemQuantity;
        this.CrItem.ItemCategoryId = _Item.ItemCategoryId;
        this.Opration = "Edit";
        console.log(_Item);
        JSON.stringify(this.CrItem);
    }

    GetCategoryName(categoryId: number) {
        //var myCat = this.ItemCategorys.filter(c => c.CategoryId == categoryId)[0].CategoryName;
        var myCat = this.ItemCategorys.find(c => c.CategoryId == categoryId).CategoryName; // Need to change tsconfig.json "target": "es6",
        return myCat;
    }

    
}
