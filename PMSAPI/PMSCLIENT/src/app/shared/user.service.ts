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
      LastName: user.LastName
    }
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(this.rootUrl + '/api/User/Register', body,{headers : reqHeader});
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