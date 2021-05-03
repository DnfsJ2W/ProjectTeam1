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
