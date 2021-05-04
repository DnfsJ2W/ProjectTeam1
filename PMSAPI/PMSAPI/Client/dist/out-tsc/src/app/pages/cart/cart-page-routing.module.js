import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CartPageComponent } from './cart-page.component';
const cartPageRoutes = [{ path: '', component: CartPageComponent }];
let CartRoutingModule = class CartRoutingModule {
};
CartRoutingModule = __decorate([
    NgModule({
        imports: [RouterModule.forChild(cartPageRoutes)],
        exports: [RouterModule]
    })
], CartRoutingModule);
export { CartRoutingModule };
//# sourceMappingURL=cart-page-routing.module.js.map