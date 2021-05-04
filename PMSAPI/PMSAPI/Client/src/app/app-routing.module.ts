import { RouterModule, Routes } from '@angular/router'
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { AuthGuard } from './auth/auth.guard';

export const appRoutes:Routes=[
    {
        path:'',
        redirectTo:'category',
        pathMatch:'full'
    },
    {
        path:'category',
        loadChildren: () => import('./pages/category/category.module').then(m => m.CategoryModule)
    },
    {
        path:'product',
        loadChildren: () => import('./pages/product/product.module').then(s => s.ProductModule)
    },
    {
        path:'cart',
        loadChildren: () => import('./pages/cart/cart-page.module').then(n => n.CartPageModule)
    },
    { 
        path: 'home', 
        component: HomeComponent,
        canActivate:[AuthGuard]
    },
    {
        path: 'signup', component: UserComponent,
        children: [{ path: '', component: SignUpComponent }]
    },
    {
        path: 'login', component: UserComponent,
        children: [{ path: '', component: SignInComponent }]
    },
    {
        path:'**',
        loadChildren: () => import('./pages/category/category.module').then(t => t.CategoryModule)
    },
    { 
        path : 'login',
         redirectTo:'/login',
          pathMatch : 'full'
    }

];
export class AppRoutingModule{}