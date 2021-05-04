import { __decorate, __metadata } from "tslib";
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';
let HomeComponent = class HomeComponent {
    constructor(router, userService) {
        this.router = router;
        this.userService = userService;
    }
    ngOnInit() {
        // this.userService.getUserClaims().subscribe((data: any) => {
        //   this.userClaims = data;
        // });
    }
    Logout() {
        localStorage.removeItem('userToken');
        this.router.navigate(['/category']);
    }
};
HomeComponent = __decorate([
    Component({
        selector: 'app-home',
        templateUrl: './home.component.html',
        styleUrls: ['./home.component.css']
    }),
    __metadata("design:paramtypes", [Router, UserService])
], HomeComponent);
export { HomeComponent };
//# sourceMappingURL=home.component.js.map