import { __decorate } from "tslib";
import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { SharedModule } from "../../shared/shared.module";
//import {RouterModule} from "@angular/router";
import { CartPageComponent } from "./cart-page.component";
//import {cartPageRoutes} from "./cart-page-routing.module";
import { CartRoutingModule } from "./cart-page-routing.module";
let CartPageModule = class CartPageModule {
};
CartPageModule = __decorate([
    NgModule({
        imports: [
            CommonModule,
            SharedModule,
            //RouterModule.forChild(cartPageRoutes),
            CartRoutingModule
        ],
        declarations: [
            CartPageComponent
        ]
    })
], CartPageModule);
export { CartPageModule };
//# sourceMappingURL=cart-page.module.js.map