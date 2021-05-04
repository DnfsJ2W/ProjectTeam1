import { __decorate, __metadata } from "tslib";
import { Component } from '@angular/core';
import { CartBaseComponent } from "./cart-base.component";
import { CartService } from "../../services/cart.service";
let CartPageComponent = class CartPageComponent extends CartBaseComponent {
    constructor(cartService) {
        super(cartService);
        this.cartService = cartService;
        this.changeQuantity = (cart, quantity) => {
            cart.quantity = quantity;
            this.cartService.reloadCart(this.cartList);
        };
    }
    ngOnInit() {
    }
};
CartPageComponent = __decorate([
    Component({
        selector: 'app-cart-page',
        styleUrls: ["cart-page.component.css"],
        templateUrl: 'cart-page.component.html'
    }),
    __metadata("design:paramtypes", [CartService])
], CartPageComponent);
export { CartPageComponent };
//# sourceMappingURL=cart-page.component.js.map