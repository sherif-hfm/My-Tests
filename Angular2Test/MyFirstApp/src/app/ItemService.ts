import { Injectable } from '@angular/core';
import { Item } from './Models';
import { ItemCategory } from './Models';

@Injectable()
export class ItemService {
    private items: Item[];
    private ItemCategorys: ItemCategory[];

    constructor() { }

    getItems() {
        
        this.items = [
            { ItemId: "1", ItemName: "Item-1", ItemPrice: 10, ItemCategoryId: 1, ItemQuantity: 100 },
            { ItemId: "2", ItemName: "Item-2", ItemPrice: 20.20, ItemCategoryId: 1, ItemQuantity: 200 },
            { ItemId: "3", ItemName: "Item-3", ItemPrice: 30.30, ItemCategoryId: 2, ItemQuantity: 300 },
            { ItemId: "4", ItemName: "Item-4", ItemPrice: 40.40, ItemCategoryId: 2, ItemQuantity: 400 },
            { ItemId: "5", ItemName: "Item-5", ItemPrice: 50.50, ItemCategoryId: 3, ItemQuantity: 500 }
        ];
        return this.items;
    }

    getItemCategorys() {
        
        this.ItemCategorys = [
            { CategoryId: 1, CategoryName: "Cat1" },
            { CategoryId: 2, CategoryName: "Cat2" },
            { CategoryId: 3, CategoryName: "Cat3" },
        ];
        return this.ItemCategorys;
    }

    saveItem(CrItem: Item) {
        if (CrItem.ItemId == null) {
            console.log('Save Add');
            var maxItemId = Math.max.apply(Math, this.items.map(function (o) { return o.ItemId; }));
            CrItem.ItemId = maxItemId + 1;
            this.items.push(CrItem);
        }
        else {
            console.log('Save Edit');
            var myItem = this.items.find(i => i.ItemId == CrItem.ItemId);// Need to change tsconfig.json "target": "es6",
            myItem.ItemName = CrItem.ItemName;
            myItem.ItemPrice = CrItem.ItemPrice;
            myItem.ItemQuantity = CrItem.ItemQuantity;
            myItem.ItemCategoryId = CrItem.ItemCategoryId;
        }
    }
}