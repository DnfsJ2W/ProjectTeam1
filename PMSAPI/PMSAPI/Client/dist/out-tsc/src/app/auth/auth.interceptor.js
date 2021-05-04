import { __decorate, __metadata } from "tslib";
import 'rxjs/add/operator/do';
import { tap } from 'rxjs/operators';
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
let AuthInterceptor = class AuthInterceptor {
    constructor(router) {
        this.router = router;
    }
    intercept(req, next) {
        if (req.headers.get('No-Auth') == "True")
            return next.handle(req.clone());
        if (localStorage.getItem('userToken') != null) {
            const clonedreq = req.clone({
                headers: req.headers.set("Authorization", "Bearer " + localStorage.getItem('userToken'))
            });
            return next.handle(clonedreq).pipe(tap(succ => { }, err => {
                if (err.status === 401)
                    this.router.navigateByUrl('/login');
            }));
        }
        else {
            this.router.navigateByUrl('/category');
        }
    }
};
AuthInterceptor = __decorate([
    Injectable(),
    __metadata("design:paramtypes", [Router])
], AuthInterceptor);
export { AuthInterceptor };
//# sourceMappingURL=auth.interceptor.js.map