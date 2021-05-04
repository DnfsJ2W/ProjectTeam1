import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { BehaviorSubject } from "rxjs";
let CartService = class CartService {
    constructor() {
        this.cartListSubject = new BehaviorSubject([]);
        this.toggleCartSubject = new BehaviorSubject(false);
        this.toggleCart = () => {
            this.toggleCartSubject.next(!this.toggleCartSubject.getValue());
        };
        this.addToCart = (cart) => {
            let current = this.cartListSubject.getValue();
            let dup = current.find(c => c.product.title === cart.product.title);
            if (dup)
                dup.quantity += cart.quantity;
            else
                current.push(cart);
            this.cartListSubject.next(current);
        };
        this.reloadCart = (cartList) => {
            this.cartListSubject.next(cartList);
        };
        this.removeCart = index => {
            let current = this.cartListSubject.getValue();
            current.splice(index, 1);
            this.cartListSubject.next(current);
        };
    }
};
CartService = __decorate([
    Injectable()
], CartService);
export { CartService };
//# sourceMappingURL=cart.service.js.map