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
let DomControlComponent = class DomControlComponent {
    btn_Click() {
        var btns = window.document.getElementsByTagName('button'); // get all button tag even outside the component
        btns[0].textContent = "OK";
        console.log(window.document.getElementsByTagName('button'));
        console.log('btn_Click');
    }
};
DomControlComponent = __decorate([
    core_1.Component({
        selector: 'DomControl',
        templateUrl: './app/dom-control.component.html',
        styleUrls: ['./app/dom-control.component.css'],
    }), 
    __metadata('design:paramtypes', [])
], DomControlComponent);
exports.DomControlComponent = DomControlComponent;
//# sourceMappingURL=dom-control.component.js.map