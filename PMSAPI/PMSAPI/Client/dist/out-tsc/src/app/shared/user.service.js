import { __decorate, __metadata } from "tslib";
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
let UserService = class UserService {
    constructor(http) {
        this.http = http;
        this.rootUrl = 'https://localhost:44326';
    }
    registerUser(user) {
        const body = {
            UserName: user.UserName,
            Password: user.Password,
            Email: user.Email,
            FirstName: user.FirstName,
            LastName: user.LastName,
            PhoneNumber: user.PhoneNumber,
            State: user.State,
            Country: user.Country,
            City: user.City,
            PinCode: user.PinCode,
            StreetAddress: user.StreetAddress,
            ConfirmPassword: user.ConfirmPassword
        };
        var reqHeader = new HttpHeaders({ 'No-Auth': 'True', 'Content-Type': 'application/json' });
        return this.http.post(this.rootUrl + '/api/Account/Register', body, { headers: reqHeader });
    }
    userAuthentication(userName, password) {
        var data = "username=" + userName + "&password=" + password + "&grant_type=password";
        var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json;charset=UTF-8', 'No-Auth': 'True' });
        return this.http.post(this.rootUrl + '/token', data, { headers: reqHeader });
    }
};
UserService = __decorate([
    Injectable(),
    __metadata("design:paramtypes", [HttpClient])
], UserService);
export { UserService };
//# sourceMappingURL=user.service.js.map