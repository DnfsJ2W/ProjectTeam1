import { __decorate, __metadata } from "tslib";
import { Component } from '@angular/core';
import { ProductService } from "../../services/products.service";
import { CartService } from "../../services/cart.service";
import { Router } from "@angular/router";
let CategoryComponent = class CategoryComponent {
    constructor(productService, cartService, router) {
        this.productService = productService;
        this.cartService = cartService;
        this.router = router;
        this.load = () => {
            this.sub = this.productService.getProducts('.\\Scripts\\client\\assets\\mock-data\\products.json').subscribe(data => {
                console.log(data);
                this.products = data;
            }, err => {
                console.log(err);
            }
            /*(res: any) => {
            this.products = res;
        }*/ );
        };
        this.addToCart = (product) => {
            this.cartService.addToCart({ product, quantity: 1 });
        };
    }
    ngOnInit() {
        this.load();
    }
    ngOnDestroy() {
        this.sub.unsubscribe();
    }
};
CategoryComponent = __decorate([
    Component({
        selector: 'app-category',
        templateUrl: './category.component.html',
        styleUrls: ['./category.component.css']
    }),
    __metadata("design:paramtypes", [ProductService,
        CartService,
        Router])
], CategoryComponent);
export { CategoryComponent };
//# sourceMappingURL=category.component.js.map