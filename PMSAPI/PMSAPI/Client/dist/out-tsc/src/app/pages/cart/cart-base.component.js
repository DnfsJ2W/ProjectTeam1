export class CartBaseComponent {
    constructor(cartService) {
        this.cartService = cartService;
        this.loadCart = () => {
            this.cartService.cartListSubject
                .subscribe(res => {
                this.cartList = res;
                let total = 0;
                for (let cart of this.cartList) {
                    total += cart.product.price * cart.quantity;
                }
                this.totalPrice = total;
            });
        };
        this.removeFromCart = index => {
            this.cartService.removeCart(index);
        };
        this.loadCart();
    }
}
//# sourceMappingURL=cart-base.component.js.map