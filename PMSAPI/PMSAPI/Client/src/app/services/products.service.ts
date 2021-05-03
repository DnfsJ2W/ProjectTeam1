import {Injectable} from "@angular/core";
import {HttpClient,HttpResponse} from "@angular/common/http";
import {Observable} from "rxjs";
import { map } from 'rxjs/operators';

@Injectable()
export class ProductService {

    constructor(public http: HttpClient) { }

    public getProducts(dataURL:string){
        return this.http.get(dataURL).pipe(
            map((res:Response) => res.json()));
            //.catch((error:any) => Observable.throw(error || 'Server error'));
    }
}