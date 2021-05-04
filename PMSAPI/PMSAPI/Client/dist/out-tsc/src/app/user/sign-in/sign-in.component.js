import { __decorate, __metadata } from "tslib";
import { Component } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { Router } from '@angular/router';
let SignInComponent = class SignInComponent {
    constructor(userService, router) {
        this.userService = userService;
        this.router = router;
        this.isLoginError = false;
    }
    ngOnInit() {
    }
    OnSubmit(userName, password) {
        this.userService.userAuthentication(userName, password).subscribe((data) => {
            localStorage.setItem('userToken', data.access_token);
            this.router.navigate(['/home']);
        }, (err) => {
            console.log(err);
            this.isLoginError = true;
        });
    }
};
SignInComponent = __decorate([
    Component({
        selector: 'app-sign-in',
        templateUrl: './sign-in.component.html',
        styleUrls: ['./sign-in.component.css']
    }),
    __metadata("design:paramtypes", [UserService, Router])
], SignInComponent);
export { SignInComponent };
//# sourceMappingURL=sign-in.component.js.map