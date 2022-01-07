import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { UpdateUserModel } from 'src/app/_models/user/updateUserModel';
import { UserSkillModel } from 'src/app/_models/user/userSkillModel';
 
@Injectable()
export class UserService {
 
    private url = "/api/user";
 
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

    getSkills() {
        return this.http.get(this.url + "/getSkills");
    }

    addSkill(userSkillModel: UserSkillModel) {
        return this.http.post(this.url + "/addSkill", userSkillModel);
    }

    deleteSkill(userSkillModel: UserSkillModel) {
        const options = {
            headers: new HttpHeaders({
              'Content-Type': 'application/json',
            }),
            body: userSkillModel
          };
        return this.http.delete(this.url + '/deleteSkill', options);
    }
}