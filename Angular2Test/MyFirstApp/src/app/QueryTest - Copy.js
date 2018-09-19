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
let QueryTestComponent = class QueryTestComponent {
    ngAfterContentInit() {
        console.log('ngAfterContentInit');
    }
    ngAfterViewInit() {
        console.log('ngAfterViewInit');
        console.log('ViewChildren');
        console.log(this.childs);
        console.log("childs[0]" + this.childs.first);
        setTimeout(() => { this.childs.first.UpdateValue("My Data2"); }, 0);
        console.log('ContentChildren');
        console.log(this.childs2);
        setTimeout(() => { this.childs2.first.UpdateValue("My Data3"); }, 0);
    }
};
__decorate([
    core_1.ViewChildren('ChildTest'), 
    __metadata('design:type', core_1.QueryList)
], QueryTestComponent.prototype, "childs", void 0);
__decorate([
    // do not work with ngIf
    core_1.ContentChildren('ChildTest'), 
    __metadata('design:type', core_1.QueryList)
], QueryTestComponent.prototype, "childs2", void 0);
QueryTestComponent = __decorate([
    core_1.Component({
        selector: 'QueryTest',
        templateUrl: './app/QueryTest.html',
        styleUrls: ['./app/QueryTest.css'],
        providers: [core_1.QueryList],
    }), 
    __metadata('design:paramtypes', [])
], QueryTestComponent);
exports.QueryTestComponent = QueryTestComponent;
//# sourceMappingURL=QueryTest - Copy.js.map