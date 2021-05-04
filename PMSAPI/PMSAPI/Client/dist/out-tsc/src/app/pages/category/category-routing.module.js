import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CategoryComponent } from './category.component';
const categoryRoutes = [{ path: '', component: CategoryComponent }];
let CategoryRoutingModule = class CategoryRoutingModule {
};
CategoryRoutingModule = __decorate([
    NgModule({
        imports: [RouterModule.forChild(categoryRoutes)],
        exports: [RouterModule]
    })
], CategoryRoutingModule);
export { CategoryRoutingModule };
//# sourceMappingURL=category-routing.module.js.map