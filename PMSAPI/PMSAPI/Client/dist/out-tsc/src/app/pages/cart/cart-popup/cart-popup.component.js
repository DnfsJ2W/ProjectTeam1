import { __decorate, __metadata } from "tslib";
import { Component, HostBinding, ElementRef } from "@angular/core";
import { CartService } from "../../../services/cart.service";
import { CartBaseComponent } from "../cart-base.component";
let CartPopupComponent = class CartPopupComponent extends CartBaseComponent {
    constructor(cartService, eleref) {
        super(cartService);
        this.cartService = cartService;
        this.eleref = eleref;
        this.isVisible = false;
        this.onPageClick = (event) => {
            if (this.isVisible && !this.eleref.nativeElement.contains(event.target) && event.target.className !== 'cart-remove') {
                this.cartService.toggleCart();
            }
        };
    }
    ngOnInit() {
        this.cartService.toggleCartSubject.subscribe(res => {
            this.isVisible = res;
        });
    }
};
__decorate([
    HostBinding("class.visible"),
    __metadata("design:type", Boolean)
], CartPopupComponent.prototype, "isVisible", void 0);
CartPopupComponent = __decorate([
    Component({
        selector: 'cart-popup',
        styleUrls: ["cart-popup.component.css"],
        templateUrl: 'cart-popup.component.html',
        host: {
            '(document:click)': 'onPageClick($event)',
        }
    }),
    __metadata("design:paramtypes", [CartService,
        ElementRef])
], CartPopupComponent);
export { CartPopupComponent };
//# sourceMappingURL=cart-popup.component.js.map