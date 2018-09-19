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
let DataBindingComponent = class DataBindingComponent {
    constructor() {
        this.name = 'UserData 1';
        this.lableClass = 'lable2';
        this.titleClass = "Title";
        this.addTitleClass = false;
        this.myStyle = { 'color': 'red' };
        this.myStyleColor = "red";
        this.myValue = "welcome";
        console.log('constructor');
    }
    btn1Click(event) {
        console.log('Click');
        console.log(event);
    }
    btn1MouseOver(event) {
    }
    txtUserName_keyup(txtUserName) {
        console.log(txtUserName.value);
        console.log(txtUserName.data);
    }
    text_Ckange(data) {
        console.log(data);
    }
};
DataBindingComponent = __decorate([
    core_1.Component({
        selector: 'DataBinding',
        templateUrl: './app/data-binding.component.html',
        styleUrls: ['./app/data-binding.component.css']
    }), 
    __metadata('design:paramtypes', [])
], DataBindingComponent);
exports.DataBindingComponent = DataBindingComponent;
//# sourceMappingURL=data-binding.component.js.map