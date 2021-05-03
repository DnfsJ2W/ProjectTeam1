import {NgModule} from "@angular/core";
import { CommonModule } from '@angular/common';
//import {RouterModule} from "@angular/router";
//import {categoryRoutes} from "./category-routing.module";
import {SharedModule} from "../../shared/shared.module";
import {CategoryComponent} from "./category.component";
import { CategoryRoutingModule } from "./category-routing.module";
@NgModule({
    imports: [
        CommonModule,
        SharedModule,
        //RouterModule.forChild(categoryRoutes),
        CategoryRoutingModule
    ],
    declarations: [
        CategoryComponent
    ]
})
export class CategoryModule { }