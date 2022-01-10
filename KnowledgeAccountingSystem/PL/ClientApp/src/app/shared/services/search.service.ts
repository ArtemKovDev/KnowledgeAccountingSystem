import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { RoleModel } from 'src/app/_models/role/RoleModel';
import { UserModel } from 'src/app/_models/user/userModel';
 
@Injectable()
export class SearchService {
 
    private url = "/api/search";
 
    constructor(private http: HttpClient) {
    }

    getUsers() {
        return this.http.get(this.url + "/getUsers");
    }
    getUsersBySkill(id: number) {
        return this.http.get(this.url + '/getUsers/skill/' + id);
    }
    getUsersInRole(role: RoleModel) {
        return this.http.post<UserModel[]>(this.url + "/getUsers/role", role);
    }
}