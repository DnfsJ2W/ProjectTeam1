import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductComponent } from './product.component'
export const productRoutes: Routes = [{ path : '', component: ProductComponent}]

@NgModule({
    imports : [RouterModule.forChild(productRoutes)],
    exports : [RouterModule]
})
export class ProductRoutingModule{}