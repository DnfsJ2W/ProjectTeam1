import {Injectable} from "@angular/core";
import {HttpClient,HttpErrorResponse,HttpResponse} from "@angular/common/http";
import {Observable} from "rxjs/Rx";
import { map,catchError } from 'rxjs/operators';
import { Product } from "../model/product";
import { throwError } from "rxjs";

@Injectable()
export class ProductService {

    constructor(public http: HttpClient) { }

    public getProducts(dataURL:string){
   

debugger;
//console.log(this.http.get<Product[]>(dataURL));
         return this.http.get(dataURL).pipe(
             map((res:Response) => {
                 return res.json();
             }), catchError ( error => {
                 return throwError('Somthing went wrong!');
             })
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
