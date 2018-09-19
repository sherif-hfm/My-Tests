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
const Models_1 = require('./Models');
const ItemService_1 = require('./ItemService');
let ItemsListComponent = class ItemsListComponent {
    constructor(itemService) {
        this.itemService = itemService;
        this.CrItem = new Models_1.Item();
        this.Opration = "List";
        this.submitted = false;
        console.log('constructor');
        this.ItemCategorys = itemService.getItemCategorys();
        this.items = itemService.getItems();
    }
    SaveItem(item) {
        console.log('SaveItem' + item);
        if (item != null) {
            console.log(item);
            this.itemService.saveItem(item);
        }
        this.Opration = "List";
    }
    btnAddItem_Click() {
        console.log('btnAddItem_Click ');
        this.CrItem = new Models_1.Item();
        this.Opration = "Add";
    }
    btnEditItem_Click(_Item) {
        console.log('btnEditItem_Click ' + _Item.ItemId);
        this.CrItem = new Models_1.Item();
        this.CrItem.ItemId = _Item.ItemId;
        this.CrItem.ItemName = _Item.ItemName;
        this.CrItem.ItemPrice = _Item.ItemPrice;
        this.CrItem.ItemQuantity = _Item.ItemQuantity;
        this.CrItem.ItemCategoryId = _Item.ItemCategoryId;
        this.Opration = "Edit";
        console.log(_Item);
        JSON.stringify(this.CrItem);
    }
    GetCategoryName(categoryId) {
        //var myCat = this.ItemCategorys.filter(c => c.CategoryId == categoryId)[0].CategoryName;
        var myCat = this.ItemCategorys.find(c => c.CategoryId == categoryId).CategoryName; // Need to change tsconfig.json "target": "es6",
        return myCat;
    }
};
ItemsListComponent = __decorate([
    core_1.Component({
        selector: 'ItemsList',
        templateUrl: './app/ItemsList.html',
        styleUrls: ['./app/ItemsList.css'],
        providers: [ItemService_1.ItemService],
    }), 
    __metadata('design:paramtypes', [ItemService_1.ItemService])
], ItemsListComponent);
exports.ItemsListComponent = ItemsListComponent;
//# sourceMappingURL=ItemsList.js.map