import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { UpdateUserModel } from 'src/app/_models/user/updateUserModel';
 
@Injectable()
export class ProfileService {
 
    private url = "/api/profile";
 
    constructor(private http: HttpClient) {
    }
 
    getUserCredentials() {
        return this.http.get(this.url + "/getUserCredentials");
    }
    
    updateUserCredentials(updateUserModel: UpdateUserModel) {
        return this.http.put(this.url + "/updateUserCredentials", updateUserModel);
    }

    getRoles() {
        return this.http.get(this.url + "/getRoles");
    }
}