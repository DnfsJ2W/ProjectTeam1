import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CartPageComponent } from './cart-page.component'
const cartPageRoutes: Routes = [{ path : '', component: CartPageComponent}];

@NgModule({
    imports : [RouterModule.forChild(cartPageRoutes)],
    exports : [RouterModule]
})
export class CartRoutingModule{}