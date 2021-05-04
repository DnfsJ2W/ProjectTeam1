import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { map,catchError } from 'rxjs/operators';
import { Product } from "../model/product";

const httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json", "No-Auth" : "True"})
};

@Injectable()
export class ProductService {

  constructor(public http: HttpClient) { }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error("An error occurred:", error.error.message);
    } else {
      // The backend returned an unsuccessful response code. The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
    }
    // return an observable with a user-facing error message
    return throwError(error);
  }
  private extractData(res: Response) {
    let body = res.json();
    return body || {};
  }
  public getProducts(dataURL: string): Observable<any> {
    return this.http.get<any>(dataURL, httpOptions).pipe(
      map((res: Response) => res),
      catchError(this.handleError)
    )
  }
    endpoint = 'https://localhost:44326/api/';
  
    getProduct(PID: number) {
      return this.http.get(this.endpoint+'/GetProduct/'+PID);
    }
    postProduct(PID: number, PName: string, ProductImage: string,Pdescription: string,categoryId: any, fileToUpload: File,Price: string, Discount: string,PQuantity: string, PStatus: string,Path:string,ImageCode:any) {
        //const endpoint = 'https://localhost:44335/api/UpdateProduct/1';
    
        const formData: FormData = new FormData();
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
        console.log(PID+PName)
        console.log('service code')
        return this.http.post(this.endpoint+'/AddProduct', formData);
      }
      putProduct(PID: number, PName: string, ProductImage: string,Pdescription: string,categoryId: any, fileToUpload: File,Price: string, Discount: string,PQuantity: string, PStatus: string,Path:string,ImageCode:any) {
        //const endpoint = 'https://localhost:44335/api/UpdateProduct/1';
    
        const formData: FormData = new FormData();
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
        console.log(PID+PName)
        console.log('service code')
        return this.http.put(this.endpoint+'UpdateProduct/'+PID, formData);
      }
         //.pipe(
             //map((res:Response) => res.json())
             //catchError((error: HttpErrorResponse) => { 
               //  console.log(error)
             //   }
           // )
         //);
         //.pipe(
        //    map((res:Response) => res.json()
            
           
            //));

            //.catch((error:any) => Observable.throw(error || 'Server error'));
    }
