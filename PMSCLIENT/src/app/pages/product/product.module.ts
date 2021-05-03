import {NgModule} from "@angular/core";
import { CommonModule } from '@angular/common';
//import {RouterModule} from "@angular/router";
//import { productRoutes} from "./product-routing.module";
import {SharedModule} from "../../shared/shared.module";
import {ProductComponent} from "./product.component";
import { ProductRoutingModule } from "./product-routing.module";

@NgModule({
    imports: [
        CommonModule,
        SharedModule,
        //RouterModule.forChild(productRoutes),
        ProductRoutingModule
    ],
    declarations: [
        ProductComponent,
    ]
})
export class ProductModule { }