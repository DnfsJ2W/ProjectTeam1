import { __decorate, __metadata } from "tslib";
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../shared/user.service';
let SignUpComponent = class SignUpComponent {
    constructor(userService, toastr, router) {
        this.userService = userService;
        this.toastr = toastr;
        this.router = router;
        this.emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
    }
    ngOnInit() {
        this.resetForm();
    }
    resetForm(form) {
        if (form != null)
            form.reset();
        this.user = {
            UserName: '',
            Password: '',
            Email: '',
            FirstName: '',
            LastName: '',
            PhoneNumber: '',
            State: '',
            Country: '',
            City: '',
            PinCode: '',
            StreetAddress: '',
            ConfirmPassword: ''
        };
    }
    OnSubmit(form) {
        this.userService.registerUser(form.value)
            .subscribe((data) => {
            debugger;
            console.log(data);
            if (data.Succeeded == true) {
                this.resetForm(form);
                this.toastr.success('User registration successful');
                debugger;
                this.router.navigate(['/login']);
            }
            else
                this.toastr.error(data.Errors[0]);
        });
    }
};
SignUpComponent = __decorate([
    Component({
        selector: 'app-sign-up',
        templateUrl: './sign-up.component.html',
        styleUrls: ['./sign-up.component.css']
    }),
    __metadata("design:paramtypes", [UserService, ToastrService, Router])
], SignUpComponent);
export { SignUpComponent };
//# sourceMappingURL=sign-up.component.js.map