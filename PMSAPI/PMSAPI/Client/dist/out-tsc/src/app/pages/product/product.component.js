import { __decorate, __metadata } from "tslib";
import { Component } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { ProductService } from "../../services/products.service";
import { CartService } from "../../services/cart.service";
let ProductComponent = class ProductComponent {
    constructor(route, productService, cartService) {
        this.route = route;
        this.productService = productService;
        this.cartService = cartService;
        this.quantity = 1;
        this.getProduct = (id) => {
            this.sub = this.productService.getProducts('./Scripts/client/assets/mock-data/products.json')
                .subscribe(res => {
                this.product = res[id - 1];
            });
        };
        this.changeQuantity = (newQuantity) => {
            this.quantity = newQuantity;
        };
        this.addToCart = (product) => {
            if (this.quantity)
                this.cartService.addToCart({ product, quantity: this.quantity });
        };
    }
    ngOnInit() {
        this.route.params
            .subscribe(res => {
            this.getProduct(res.id);
        });
    }
    ngOnDestroy() {
        this.sub.unsubscribe();
    }
};
ProductComponent = __decorate([
    Component({
        selector: 'app-product',
        templateUrl: './product.component.html',
        styleUrls: ['./product.component.css']
    }),
    __metadata("design:paramtypes", [ActivatedRoute,
        ProductService,
        CartService])
], ProductComponent);
export { ProductComponent };
//# sourceMappingURL=product.component.js.map