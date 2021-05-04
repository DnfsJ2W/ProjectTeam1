import { __decorate, __metadata } from "tslib";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map, catchError } from 'rxjs/operators';
import { throwError } from "rxjs";
let ProductService = class ProductService {
    constructor(http) {
        this.http = http;
        this.endpoint = 'https://localhost:44326/api/';
    }
    getProducts(dataURL) {
        debugger;
        //console.log(this.http.get<Product[]>(dataURL));
        return this.http.get(dataURL).pipe(map((res) => {
            return res.json();
        }), catchError(error => {
            return throwError('Somthing went wrong!');
        }));
    }
    getProduct(PID) {
        return this.http.get(this.endpoint + '/GetProduct/' + PID);
    }
    postProduct(PID, PName, ProductImage, Pdescription, categoryId, fileToUpload, Price, Discount, PQuantity, PStatus, Path, ImageCode) {
        //const endpoint = 'https://localhost:44335/api/UpdateProduct/1';
        const formData = new FormData();
        formData.append('PImage', fileToUpload, fileToUpload.name);
        formData.append('PName', PName);
        formData.append('ProductImage', ProductImage);
        formData.append('Pdescription', Pdescription);
        formData.append('Discount', Discount);
        formData.append('Price', Price);
        formData.append('CategoryId', categoryId);
        formData.append('PQuantity', PQuantity);
        formData.append('PStatus', PStatus);
        formData.append('Path', Path);
        formData.append('ImageCode', ImageCode);
        console.log(PID + PName);
        console.log('service code');
        return this.http.post(this.endpoint + '/AddProduct', formData);
    }
    putProduct(PID, PName, ProductImage, Pdescription, categoryId, fileToUpload, Price, Discount, PQuantity, PStatus, Path, ImageCode) {
        //const endpoint = 'https://localhost:44335/api/UpdateProduct/1';
        const formData = new FormData();
        //formData.append('Image', fileToUpload, fileToUpload.name);
        formData.append('PName', PName);
        formData.append('ProductImage', ProductImage);
        formData.append('Pdescription', Pdescription);
        formData.append('Discount', Discount);
        formData.append('Price', Price);
        formData.append('CategoryId', categoryId);
        formData.append('PQuantity', PQuantity);
        formData.append('PStatus', PStatus);
        formData.append('Path', Path);
        formData.append('ImageCode', ImageCode);
        console.log(PID + PName);
        console.log('service code');
        return this.http.put(this.endpoint + 'UpdateProduct/' + PID, formData);
    }
};
ProductService = __decorate([
    Injectable(),
    __metadata("design:paramtypes", [HttpClient])
], ProductService);
export { ProductService };
//# sourceMappingURL=products.service.js.map