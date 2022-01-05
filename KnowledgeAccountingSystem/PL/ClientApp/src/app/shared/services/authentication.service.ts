import { RegisterModel } from './../../_interfaces/user/registerModel.model'; 
import { RegistrationResponseModel } from './../../_interfaces/response/registrationResponseModel.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor(private _http: HttpClient) { }
  public registerUser = (body: RegisterModel) => {
    return this._http.post<RegistrationResponseModel> ("https://localhost:44335/api/account/register", body);
  }
}
