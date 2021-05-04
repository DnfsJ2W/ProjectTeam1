import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProductComponent } from './product.component';
export const productRoutes = [{ path: '', component: ProductComponent }];
let ProductRoutingModule = class ProductRoutingModule {
};
ProductRoutingModule = __decorate([
    NgModule({
        imports: [RouterModule.forChild(productRoutes)],
        exports: [RouterModule]
    })
], ProductRoutingModule);
export { ProductRoutingModule };
//# sourceMappingURL=product-routing.module.js.map