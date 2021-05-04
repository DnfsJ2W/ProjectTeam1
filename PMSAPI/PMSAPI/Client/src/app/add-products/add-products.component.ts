import { convertActionBinding } from '@angular/compiler/src/compiler_util/expression_converter';
import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import { Component, OnInit } from '@angular/core';
import {ProductService} from "../services/products.service";

@Component({
  selector: 'app-add-products',
  templateUrl: './add-products.component.html',
  styleUrls: ['./add-products.component.css']
})
export class AddProductsComponent implements OnInit {

  imageUrl: string = "/assets/img/UploadLogo.jpg";
  fileToUpload: File = null;
  PID: any;
  ProductName:any;
  ProductImage:any;
  Pdescription:any;
  categoryId:any;
  ImageCode: any;
  Price:any;
  Discount:any;
  Quantity:any;
  IsStock:boolean;
  Path:any;
  retrievedImage:any;
  base64Data: any;
  retrieveResonse: any;
  p:any = new Product();


  constructor(private productService : ProductService) {

  }

  ngOnInit(): void {
   // this.getProductById();
  }
  
  getProductById(){
    this.productService.getProduct(2).subscribe(response => {

      this.p = response;
      this.PID=this.p.PID;
      this.ProductName=this.p.ProductName;
      this.ProductImage=this.p.ImageName;
      this.Pdescription =this.p.Pdescription;
      this.categoryId =this.p.categoryId;
      this.ImageCode=this.p.ImageCode;
      this.Price=this.p.Price;
      this.Discount=this.p.Discount;
      this.Quantity=this.p.Quantity;
      this.IsStock=this.p.IsStock;
      this.Path=this.p.Path;
      this.retrieveResonse = response;

      this.base64Data = this.ImageCode;
      this.retrievedImage = 'data:image/jpeg;base64,' + this.base64Data;
    },
    error=>{
      alert('An unexpected error occured');
      console.log(error);
    });

}

  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);
    console.log(this.fileToUpload)
    //Show image preview
    var reader = new FileReader();
    reader.onload = (event:any) => {
      this.imageUrl = event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }

   OnSubmit(PID, ProductName,ProductImage,Pdescription,categoryId,Image,Price,Discount,Quantity,IsStock,Path,ImageCode){
    /*this.productService.postProduct(PID,ProductName,ProductImage,Pdescription,categoryId,this.fileToUpload,Price,Discount,Quantity,IsStock,Path,ImageCode).subscribe(
      data =>{
        console.log('done');
        this.PID=null;
        this.ProductName = null;
        this.ProductImage=null;
        this.Pdescription =null;
        this.categoryId =null;
        this.Price=null;
        this.Discount=null;
        this.Quantity=null;
        this.IsStock=null;
        this.Path=null;
        Image = null;
        this.Path = "/assets/img/default-image.png";
      }
    );*/
   }
}

class Product {
  PID:any;
  ProductName:any;
  ProductImage:any;
  Pdescription:any;
  categoryId:any;
  ImageCode:any;
  Price:any;
  Discount:any;
  Quantity:any;
  IsStock:any;
  Path:any;
}



