import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { UserSkillModel } from 'src/app/_models/user/userSkillModel';
import { ResponseModel } from 'src/app/_models/response/responseModel.model';
 
@Injectable()
export class UserService {
 
    private url = "/api/user";
 
    constructor(private http: HttpClient) {
    }

    getSkills() {
        return this.http.get(this.url + "/getSkills");
    }

    addSkill(userSkillModel: UserSkillModel) {
        return this.http.post<ResponseModel>(this.url + "/addSkill", userSkillModel);
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