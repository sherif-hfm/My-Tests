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
var core_1 = require('@angular/core');
var UserDataComponent = (function () {
    function UserDataComponent() {
        this.name = 'UserData 1';
        this.lableClass = 'lable2';
        console.log('constructor');
        this.items = [
            { ItemId: "1", ItemName: "Item1", ItemPrice: 10, ItemCategoryId: 11, ItemQuantity: 100 },
            { ItemId: "2", ItemName: "Item2", ItemPrice: 20.30, ItemCategoryId: 22, ItemQuantity: 200 }
        ];
        //this.items[0] = new ItemClass();
    }
    UserDataComponent.prototype.btn1Click = function (event) {
        console.log('Click');
        console.log(event);
    };
    UserDataComponent.prototype.btn1MouseOver = function (event) {
    };
    UserDataComponent.prototype.txtUserName_keyup = function (txtUserName) {
        console.log(txtUserName.value);
        console.log(txtUserName.data);
    };
    UserDataComponent = __decorate([
        core_1.Component({
            selector: 'UserData',
            templateUrl: './app/UserData.html',
            styleUrls: ['./app/UserData.css']
        }), 
        __metadata('design:paramtypes', [])
    ], UserDataComponent);
    return UserDataComponent;
}());
exports.UserDataComponent = UserDataComponent;
//# sourceMappingURL=UserData - Copy.js.map