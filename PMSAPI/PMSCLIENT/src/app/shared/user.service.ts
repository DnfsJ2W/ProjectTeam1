import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, JsonpClientBackend } from '@angular/common/http';
import { HttpResponse } from "@angular/common/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from './user.model';

@Injectable()
export class UserService {
  readonly rootUrl = 'https://localhost:44326';
  constructor(private http: HttpClient) { }

  registerUser(user: User) {
    const body: User = {
      UserName: user.UserName,
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName,
      PhoneNumber:user.PhoneNumber,
      State:user.State,
      Country:user.Country,
      City:user.City,
      PinCode:user.PinCode,
      StreetAddress:user.StreetAddress,
      ConfirmPassword:user.ConfirmPassword
    }
    var reqHeader = new HttpHeaders({'No-Auth':'True','Content-Type': 'application/json'});
    return this.http.post(this.rootUrl + '/api/Account/Register', body,{ headers: reqHeader });
  }

  userAuthentication(userName, password) {
   
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    
    var reqHeader = new HttpHeaders({'Content-Type': 'application/json;charset=UTF-8','No-Auth':'True' });

    return this.http.post(this.rootUrl + '/token', data, { headers: reqHeader });
  }

  // getUserClaims(){
  //  return  this.http.get(this.rootUrl+'/api/GetUserClaims');
  // }

}
