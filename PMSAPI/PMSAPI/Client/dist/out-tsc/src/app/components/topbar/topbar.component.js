import { __decorate, __metadata } from "tslib";
import { Component } from '@angular/core';
import { CartService } from "../../services/cart.service";
let TopbarComponent = class TopbarComponent {
    constructor(cartService) {
        this.cartService = cartService;
        this.collapse = false;
        this.toggleCartPopup = (event) => {
            event.preventDefault();
            event.stopPropagation();
            this.cartService.toggleCart();
        };
    }
    ngOnInit() {
        this.cartService.cartListSubject
            .subscribe(res => {
            this.cart_num = res.length;
        });
    }
};
TopbarComponent = __decorate([
    Component({
        selector: 'top-bar',
        styleUrls: ['./top-bar.component.css'],
        template: `    
    <div class="main-header navbar-fixed-top">
        <div class="header-menu">
            <div class="header-mobile-nav-wrapper">
                <button type="button" class="navbar-toggle" (click)="collapse = !collapse">
                    <span class="fa fa-bars fa-2x"></span>
                </button>
            </div>
            <div class="header-logo-wrapper">
                <img class="header-logo-image" src=".\\Scripts\\client\\assets\\imgs\\logobysumit.png" alt="Click N Buy!">
            </div>
            <div class="header-nav-wrapper">
                <ul class="header-nav">
                    <li class="header-nav-item">
                        <a routerLink="/">HOME</a>
                    </li>
                    <li class="header-nav-item">
                        <a routerLink="/">PRODUCTS<span class="fa fa-caret-down"></span></a>
                    </li>
                    <li class="header-nav-item">
                        <a routerLink="/login">LOGIN</a>
                    </li>
                </ul>
            </div>
            <div class="header-cart-wrapper">
                <div class="header-cart" (click)="toggleCartPopup($event)">
                    <div class="mobil-shopping-cart">
                        <span><i class="fa fa-shopping-cart fa-2x"></i> <span *ngIf="cart_num">( {{cart_num}} )</span></span>
                    </div>
                    <div class="header-cart-item">
                        <a href="">MY CART <span *ngIf="cart_num">( {{cart_num}} )</span><span class="fa fa-caret-down"></span><i class="material-icons prefix cart-image">shopping_cart</i></a>
                        
                    </div>
                </div>
            </div>
        </div>
        <ul class="mobile-header-nav" *ngIf="collapse" (click)="collapse = !collapse">
            <li>
                <a routerLink="/">HOME</a>
            </li>
            <li>
                <a routerLink="/">PRODUCTS</a>
            </li>
            <li>
                <a routerLink="/login">LOGIN</a>
            </li>
        </ul>
        <cart-popup></cart-popup>
    </div>
`
    }),
    __metadata("design:paramtypes", [CartService])
], TopbarComponent);
export { TopbarComponent };
//# sourceMappingURL=topbar.component.js.map