"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
const core_1 = require('@angular/core');
let ItemService = class ItemService {
    constructor() {
    }
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
    saveItem(CrItem) {
        if (CrItem.ItemId == null) {
            console.log('Save Add');
            var maxItemId = Math.max.apply(Math, this.items.map(function (o) { return o.ItemId; }));
            CrItem.ItemId = maxItemId + 1;
            this.items.push(CrItem);
        }
        else {
            console.log('Save Edit');
            var myItem = this.items.find(i => i.ItemId == CrItem.ItemId); // Need to change tsconfig.json "target": "es6",
            myItem.ItemName = CrItem.ItemName;
            myItem.ItemPrice = CrItem.ItemPrice;
            myItem.ItemQuantity = CrItem.ItemQuantity;
            myItem.ItemCategoryId = CrItem.ItemCategoryId;
        }
    }
};
ItemService = __decorate([
    core_1.Injectable(), 
    __metadata('design:paramtypes', [])
], ItemService);
exports.ItemService = ItemService;
//# sourceMappingURL=ItemService.js.map