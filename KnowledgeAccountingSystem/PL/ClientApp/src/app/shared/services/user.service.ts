import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { UpdateUserModel } from 'src/app/_interfaces/user/updateUserModel';
import { UserSkillViewModel } from 'src/app/_interfaces/user/userSkillViewModel';
 
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

    addSkill(userSkillViewModel: UserSkillViewModel) {
        return this.http.post(this.url + "/addSkill", userSkillViewModel);
    }

    deleteSkill(userSkillViewModel: UserSkillViewModel) {
        const options = {
            headers: new HttpHeaders({
              'Content-Type': 'application/json',
            }),
            body: userSkillViewModel
          };
        return this.http.delete(this.url + '/deleteSkill', options);
    }
}