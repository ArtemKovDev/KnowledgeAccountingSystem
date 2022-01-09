import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { RoleModel } from 'src/app/_models/role/RoleModel';
import { UserRolesModel } from 'src/app/_models/role/UserRolesModel';
import { RoleResponseModel } from 'src/app/_models/response/roleResponseModel.model';
 
@Injectable()
export class RoleService {
 
    private url = "/api/role";
 
    constructor(private http: HttpClient) {
    }

    getRoles() {
        return this.http.get(this.url + "/getRoles");
    }

    createRole(role: RoleModel) {
        return this.http.post<RoleResponseModel>(this.url + "/createRole", role);
    }

    deleteRole(role: RoleModel) {
        const options = {
            headers: new HttpHeaders({
              'Content-Type': 'application/json',
            }),
            body: role
          };
        return this.http.delete<RoleResponseModel>(this.url + "/deleteRole", options)
    }

    assignUserToRole(model: UserRolesModel){
        return this.http.post<RoleResponseModel>(this.url + "/assignUserToRole", model)
    }

    removeUserToRole(model: UserRolesModel){
        const options = {
            headers: new HttpHeaders({
              'Content-Type': 'application/json',
            }),
            body: model
          };
        return this.http.delete<RoleResponseModel>(this.url + "/removeUserFromRole", options)
    }
}