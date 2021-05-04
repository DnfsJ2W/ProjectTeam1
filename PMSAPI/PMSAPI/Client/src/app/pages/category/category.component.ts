import { Component, OnInit } from '@angular/core';
import {ProductService} from "../../services/products.service";
import {Product} from "../../model/product";
import {CartService} from "../../services/cart.service";
import {Router} from "@angular/router";
import { map } from 'rxjs/operators';

@Component({
    selector: 'app-category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
    public products:Array<Product>;
 public sub;
    constructor(
         private productService:ProductService,
         private cartService:CartService,
         private router: Router
    ) { }

    ngOnInit() {
        this.load();
    }
  load = () => {
      this.sub = this.productService.getProducts('.\\Scripts\\client\\assets\\mock-data\\products.json').subscribe(
        data => {
          console.log(data);
          this.products = data
        },
        err => {
          console.log(err);
        }
        /*(res: any) => {
        this.products = res;
    }*/)

    };
    addToCart = (product) => {
        this.cartService.addToCart({product,quantity:1})
    };
    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}
