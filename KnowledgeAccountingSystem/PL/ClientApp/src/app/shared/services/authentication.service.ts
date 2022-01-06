import { RegisterModel } from './../../_interfaces/user/registerModel.model'; 
import { LogonModel } from './../../_interfaces/user/logonModel.model'; 
import { RegistrationResponseModel } from './../../_interfaces/response/registrationResponseModel.model';
import { AuthResponseModel } from './../../_interfaces/response/authResponseModel.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private _authChangeSub = new Subject<boolean>()
  public authChanged = this._authChangeSub.asObservable();

  constructor(private _http: HttpClient, private _jwtHelper: JwtHelperService) { }

  public registerUser = (body: RegisterModel) => {
    return this._http.post<RegistrationResponseModel> ("https://localhost:44335/api/account/register", body);
  }

  public loginUser = (body: LogonModel) => {
    return this._http.post<AuthResponseModel>("https://localhost:44335/api/account/logon", body);
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this._authChangeSub.next(isAuthenticated);
  }

  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }

  public isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("token");
 
    return token && !this._jwtHelper.isTokenExpired(token);
  }
}
