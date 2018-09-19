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
const core_2 = require('@angular/core');
const Models_1 = require('./Models');
const ItemService_1 = require('./ItemService');
let ItemEditComponent = class ItemEditComponent {
    constructor(itemService) {
        this.itemService = itemService;
        this.Saved = new core_2.EventEmitter();
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
    drpItemCategoryId_Change(event) {
        console.log('drpItemCategoryId_Change');
        console.log(event[event.selectedIndex].attributes.categoryname);
        //console.log(event);
    }
};
__decorate([
    core_2.Input(), 
    __metadata('design:type', Models_1.Item)
], ItemEditComponent.prototype, "CrItem", void 0);
__decorate([
    core_2.Output(), 
    __metadata('design:type', Object)
], ItemEditComponent.prototype, "Saved", void 0);
__decorate([
    core_2.Input(), 
    __metadata('design:type', String)
], ItemEditComponent.prototype, "Opration", void 0);
ItemEditComponent = __decorate([
    core_1.Component({
        selector: 'ItemEdit',
        templateUrl: './app/ItemEdit.html',
        styleUrls: ['./app/ItemEdit.css'],
        providers: [ItemService_1.ItemService]
    }), 
    __metadata('design:paramtypes', [ItemService_1.ItemService])
], ItemEditComponent);
exports.ItemEditComponent = ItemEditComponent;
//# sourceMappingURL=ItemEdit.js.map