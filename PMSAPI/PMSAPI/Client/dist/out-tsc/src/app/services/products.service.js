import { __decorate, __metadata } from "tslib";
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { throwError } from "rxjs";
import { map, catchError } from 'rxjs/operators';
const httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json", "No-Auth": "True" })
};
let ProductService = class ProductService {
    constructor(http) {
        this.http = http;
        this.endpoint = 'https://localhost:44326/api/';
    }
    handleError(error) {
        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error("An error occurred:", error.error.message);
        }
        else {
            // The backend returned an unsuccessful response code. The response body may contain clues as to what went wrong,
            console.error(`Backend returned code ${error.status}, ` + `body was: ${error.error}`);
        }
        // return an observable with a user-facing error message
        return throwError(error);
    }
    extractData(res) {
        let body = res.json();
        return body || {};
    }
    getProducts(dataURL) {
        return this.http.get(dataURL, httpOptions).pipe(map((res) => res), catchError(this.handleError));
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