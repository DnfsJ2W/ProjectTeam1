import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
//import {HttpClient} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {RouterModule} from "@angular/router";
import {appRoutes} from "./app-routing.module";
import {TopbarComponent} from "./components/topbar/topbar.component";
import {CartService} from "./services/cart.service";
import {CartPopupComponent} from "./pages/cart/cart-popup/cart-popup.component";
import {ProductService} from "./services/products.service";
import { UserService } from './shared/user.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { HomeComponent } from './home/home.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.interceptor';
import { CategoryRoutingModule } from './pages/category/category-routing.module';
import { ProductRoutingModule } from './pages/product/product-routing.module';
import { CartRoutingModule } from './pages/cart/cart-page-routing.module';
import { CategoryModule } from './pages/category/category.module';
import { CartPageModule } from './pages/cart/cart-page.module';
import { ProductModule } from './pages/product/product.module';
import { AddProductsComponent } from './add-products/add-products.component';



@NgModule({
    declarations: [
        AppComponent,
        TopbarComponent,
        CartPopupComponent,
        SignUpComponent,
        UserComponent,
        SignInComponent,
        HomeComponent,
        AddProductsComponent
    ],
    imports: [
        BrowserAnimationsModule,
        BrowserModule,
        FormsModule,
       // HttpClient,
        HttpClientModule,
        ToastrModule.forRoot(),
        RouterModule.forRoot(appRoutes, { relativeLinkResolution: 'legacy' }),
        CategoryModule,
        CartPageModule,
        ProductModule,
        AddProductsComponent

        
    ],
    providers: [
        CartService,
        ProductService,
        UserService,
        AuthGuard,
    {
      provide : HTTP_INTERCEPTORS,
      useClass : AuthInterceptor,
      multi : true
    }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
